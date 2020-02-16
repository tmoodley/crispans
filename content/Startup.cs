using AutoMapper;
using HelpingHands.Data;
using HelpingHands.Models;
using HelpingHands.rules;
using HelpingHands.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using Vue2Spa.Providers;

namespace Vue2Spa
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            Configuration = configuration;
            CurrentEnvironment = env;
        }

        public IConfiguration Configuration { get; }
        private IHostingEnvironment CurrentEnvironment { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // IWebHostEnvironment (stored in _env) is injected into the Startup class.

            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDistributedMemoryCache();

            //services.AddHttpsRedirection(options =>
            //{
            //    options.RedirectStatusCode = StatusCodes.Status308PermanentRedirect;
            //    options.HttpsPort = 443;
            //});

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

            //add identity
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddRoles<IdentityRole>()
                .AddDefaultUI(UIFramework.Bootstrap4)
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            // Auto Mapper Configurations
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddTransient<IEmailSender, EmailSender>(i =>
               new EmailSender(
                   Configuration["EmailSender:Host"],
                   Configuration.GetValue<int>("EmailSender:Port"),
                   Configuration.GetValue<bool>("EmailSender:EnableSSL"),
                   Configuration["EmailSender:UserName"],
                   Configuration["EmailSender:Password"]
               )
           );

            services.AddTransient<IEmailAttachmentSender, EmailAttachmentSender>(i =>
                     new EmailAttachmentSender(
                         Configuration["EmailSender:Host"],
                         Configuration.GetValue<int>("EmailSender:Port"),
                         Configuration.GetValue<bool>("EmailSender:EnableSSL"),
                         Configuration["EmailSender:UserName"],
                         Configuration["EmailSender:Password"],
                         CurrentEnvironment
                     )
             );


            //Password Strength Setting
            services.Configure<IdentityOptions>(options =>
            {
                // Password settings
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = false;
                options.Password.RequiredUniqueChars = 6;

                // Lockout settings
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
                options.Lockout.MaxFailedAccessAttempts = 10;
                options.Lockout.AllowedForNewUsers = true;

                // User settings
                options.User.RequireUniqueEmail = true;
            });

            //Setting the Account Login page
            services.ConfigureApplicationCookie(options =>
            {
                // Cookie settings
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
                options.LoginPath = "/Account/Login"; // If the LoginPath is not set here,
                                                      // ASP.NET Core will default to /Account/Login
                options.LogoutPath = "/Account/Logout"; // If the LogoutPath is not set here,
                                                        // ASP.NET Core will default to /Account/Logout
                options.AccessDeniedPath = "/Account/AccessDenied"; // If the AccessDeniedPath is
                                                                    // not set here, ASP.NET Core 
                                                                    // will default to 
                                                                    // /Account/AccessDenied
                options.SlidingExpiration = true;

            });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("ElevatedRights", policy =>
                  policy.RequireRole("Administrator", "Subscriber", "Partner"));
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddSession(options =>
            {
                options.Cookie.Name = ".Capacitym.Session";
                options.IdleTimeout = TimeSpan.FromSeconds(10);
                options.Cookie.IsEssential = true;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline. 
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider serviceProvider)
        {
            //for ssl certs
            //var options = new RewriteOptions();
            //options.Rules.Add(new RedirectToNonWwwRule());
            //app.UseRewriter(options);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();

                // Webpack initialization with hot-reload.
                app.UseWebpackDevMiddleware(new WebpackDevMiddlewareOptions
                {
                    HotModuleReplacement = true,
                });
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();
            app.UseSession();
           
            CreateUserRoles(serviceProvider).Wait(); 

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                 name: "areas",
                 template: "{area:exists}/{controller=Home}/{action=Index}");

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}"); 

                routes.MapSpaFallbackRoute(
                    name: "spa-fallback",
                    defaults: new { controller = "Home", action = "Index" });
            });
        }

        private async Task CreateUserRoles(IServiceProvider serviceProvider)
        {
            try
            {
                var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                var UserManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

                IdentityResult roleResult;

                //Adding Admin Role
                var roleCheck = await RoleManager.RoleExistsAsync("Administrator");
                if (!roleCheck)
                {
                    //create the roles and seed them to the database
                    roleResult = await RoleManager.CreateAsync(new IdentityRole("Administrator"));
                }

                //Adding Partner Role
                var roleCheck2 = await RoleManager.RoleExistsAsync("Partner");
                if (!roleCheck2)
                {
                    //create the roles and seed them to the database
                    roleResult = await RoleManager.CreateAsync(new IdentityRole("Partner"));
                }
                //Assign Admin role to the main User here we have given our newly registered 
                //login id for Admin management
                ApplicationUser user = await UserManager.FindByEmailAsync("ty.moodley@gmail.com");
                ApplicationUser user2 = await UserManager.FindByEmailAsync("mgaughan72@gmail.com");
                var User = new ApplicationUser();
                await UserManager.AddToRoleAsync(user, "Administrator");
                await UserManager.AddToRoleAsync(user2, "Administrator");

                await UserManager.AddToRoleAsync(user, "Partner");
                await UserManager.AddToRoleAsync(user2, "Partner");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
