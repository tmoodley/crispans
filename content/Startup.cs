using AutoMapper;
using DataTables.AspNet.AspNetCore;
using HelpingHands.Data;
using HelpingHands.Models;
using HelpingHands.rules;
using HelpingHands.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
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
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Vue2Spa.Hubs;
using Vue2Spa.Providers;
using Vue2Spa.Services;

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

            //DataTabales
            services.RegisterDataTables(ctx =>
            {
                var appJson = ctx.ValueProvider.GetValue("appJson").FirstValue ?? "{}";
                return JsonConvert.DeserializeObject<IDictionary<string, object>>(appJson);
            }, true);

            //services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddHttpContextAccessor();

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
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);
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
                options.ExpireTimeSpan = TimeSpan.FromHours(10);
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

            services.AddMvc()
                    .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                    .AddJsonOptions(options => {
                        options.SerializerSettings.ReferenceLoopHandling =
                            Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                    });

            services.AddSignalR();

            services.AddSession(options =>
            {
                options.Cookie.Name = ".Capacitym.Session";
                options.IdleTimeout = TimeSpan.FromSeconds(10);
                options.Cookie.IsEssential = true;
            });

            var key = Encoding.ASCII.GetBytes(Configuration["AppSettings:Secret"]);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            // configure DI for application services
            services.AddScoped<IUserService, UserService>();
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
                    ConfigFile = "webpack.config.register.js", //this is defualt value
                    HotModuleReplacement = true, 
                });
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            //app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();
            app.UseSession();
           
            CreateUserRoles(serviceProvider).Wait(); 

            //app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseSignalR(routes =>
            {
                // the url most start with lower letter
                routes.MapHub<NotificationHub>("/notificationHub");
            });

            app.UseMvc(routes =>
            { 
                routes.MapRoute(
                    name: "areas",
                    template: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}"); 

                routes.MapSpaFallbackRoute(
                    name: "spa-fallback",
                    defaults: new { controller = "Portal", action = "Index" });
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

                //Adding Partner Role
                var roleCheck3 = await RoleManager.RoleExistsAsync("Bidder");
                if (!roleCheck3)
                {
                    //create the roles and seed them to the database
                    roleResult = await RoleManager.CreateAsync(new IdentityRole("Bidder"));
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


                await UserManager.AddToRoleAsync(user, "Bidder");
                await UserManager.AddToRoleAsync(user2, "Bidder");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
