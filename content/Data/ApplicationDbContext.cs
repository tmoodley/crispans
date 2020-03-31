using System;
using System.Collections.Generic;
using System.Text;
using HelpingHands.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Vue2Spa.Areas.Portal.Models;
using Vue2Spa.Models;

namespace HelpingHands.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Document> Documents { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Dependent> Dependents { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Partner> Partners { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Vue2Spa.Models.CustomerCategory> CustomerCategory { get; set; }
        public DbSet<Naics> Naics { get; set; }
        public DbSet<Vue2Spa.Models.CustomerNaics> CustomerNaics { get; set; }
        public DbSet<Capability> Capabilities { get; set; }
        public DbSet<Vue2Spa.Models.CustomerCapability> CustomerCapability { get; set; }
        public DbSet<Machine> Machines { get; set; }
        public DbSet<Vue2Spa.Models.CustomerMachine> CustomerMachine { get; set; }
        public DbSet<Industry> Industries { get; set; }
        public DbSet<Vue2Spa.Models.CustomerIndustry> CustomerIndustry { get; set; }
        public DbSet<FileType> FileTypes { get; set; }
        public DbSet<Vue2Spa.Models.CustomerFileType> CustomerFileType { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<Vue2Spa.Models.CustomerMaterial> CustomerMaterial { get; set; }
        public DbSet<Certification> Certifications { get; set; }
        public DbSet<Vue2Spa.Models.CustomerCertification> CustomerCertification { get; set; }
        public DbSet<CompanyType> CompanyTypes { get; set; }
        public DbSet<Vue2Spa.Models.CustomerCompanyType> CustomerCompanyType { get; set; }
        public DbSet<PartnerCompanyType> PartnerCompanyType { get; set; }
        public DbSet<Bidder> Bidders { get; set; }
        public DbSet<JobBid> JobBids { get; set; }

        public DbSet<JobQuestion> JobQuestions { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // I had removed this
            /// Rest of on model creating here. 
            modelBuilder.Entity<CustomerCategory>()
                .HasKey(x => new { x.CustomerId, x.CategoryId });

            modelBuilder.Entity<CustomerCategory>()
                .HasOne(bc => bc.Customer)
                .WithMany(b => b.CustomerCategories)
                .HasForeignKey(bc => bc.CustomerId);
            modelBuilder.Entity<CustomerCategory>()
                .HasOne(bc => bc.Category)
                .WithMany(c => c.CustomerCategories)
                .HasForeignKey(bc => bc.CategoryId);

            modelBuilder.Entity<CustomerNaics>()
                .HasKey(x => new { x.CustomerId, x.NaicsId });

            modelBuilder.Entity<CustomerNaics>()
                .HasOne(bc => bc.Customer)
                .WithMany(b => b.CustomerNaics)
                .HasForeignKey(bc => bc.CustomerId);
            modelBuilder.Entity<CustomerNaics>()
                .HasOne(bc => bc.Naics)
                .WithMany(c => c.CustomerNaics)
                .HasForeignKey(bc => bc.NaicsId);
              
          modelBuilder.Entity<CustomerCapability>()
                .HasKey(x => new { x.CustomerId, x.CapabilityId });

            modelBuilder.Entity<CustomerCapability>()
                .HasOne(bc => bc.Customer)
                .WithMany(b => b.CustomerCapabilities)
                .HasForeignKey(bc => bc.CustomerId);
            modelBuilder.Entity<CustomerCapability>()
                .HasOne(bc => bc.Capability)
                .WithMany(c => c.CustomerCapabilities)
                .HasForeignKey(bc => bc.CapabilityId);

        modelBuilder.Entity<CustomerMachine>()
                .HasKey(x => new { x.CustomerId, x.MachineId });

            modelBuilder.Entity<CustomerMachine>()
                .HasOne(bc => bc.Customer)
                .WithMany(b => b.CustomerMachines)
                .HasForeignKey(bc => bc.CustomerId);
            modelBuilder.Entity<CustomerMachine>()
                .HasOne(bc => bc.Machine)
                .WithMany(c => c.CustomerMachines)
                .HasForeignKey(bc => bc.MachineId);

         modelBuilder.Entity<CustomerIndustry>()
                .HasKey(x => new { x.CustomerId, x.IndustryId });

            modelBuilder.Entity<CustomerIndustry>()
                .HasOne(bc => bc.Customer)
                .WithMany(b => b.CustomerIndustries)
                .HasForeignKey(bc => bc.CustomerId);
            modelBuilder.Entity<CustomerIndustry>()
                .HasOne(bc => bc.Industry)
                .WithMany(c => c.CustomerIndustries)
                .HasForeignKey(bc => bc.IndustryId);

        modelBuilder.Entity<CustomerFileType>()
                .HasKey(x => new { x.CustomerId, x.FileTypeId });

        modelBuilder.Entity<CustomerFileType>()
            .HasOne(bc => bc.Customer)
            .WithMany(b => b.CustomerFileTypes)
            .HasForeignKey(bc => bc.CustomerId);
        modelBuilder.Entity<CustomerFileType>()
            .HasOne(bc => bc.FileType)
            .WithMany(c => c.CustomerFileTypes)
            .HasForeignKey(bc => bc.FileTypeId);

        modelBuilder.Entity<CustomerMaterial>()
                .HasKey(x => new { x.CustomerId, x.MaterialId });

        modelBuilder.Entity<CustomerMaterial>()
            .HasOne(bc => bc.Customer)
            .WithMany(b => b.CustomerMaterials)
            .HasForeignKey(bc => bc.CustomerId);
        modelBuilder.Entity<CustomerMaterial>()
            .HasOne(bc => bc.Material)
            .WithMany(c => c.CustomerMaterials)
            .HasForeignKey(bc => bc.MaterialId);

         modelBuilder.Entity<CustomerCertification>()
                .HasKey(x => new { x.CustomerId, x.CertificationId });

        modelBuilder.Entity<CustomerCertification>()
            .HasOne(bc => bc.Customer)
            .WithMany(b => b.CustomerCertifications)
            .HasForeignKey(bc => bc.CustomerId);
        modelBuilder.Entity<CustomerCertification>()
            .HasOne(bc => bc.Certification)
            .WithMany(c => c.CustomerCertifications)
            .HasForeignKey(bc => bc.CertificationId);

          modelBuilder.Entity<CustomerCompanyType>()
                .HasKey(x => new { x.CustomerId, x.CompanyTypeId });

        modelBuilder.Entity<CustomerCompanyType>()
            .HasOne(bc => bc.Customer)
            .WithMany(b => b.CustomerCompanyTypes)
            .HasForeignKey(bc => bc.CustomerId);
        modelBuilder.Entity<CustomerCompanyType>()
            .HasOne(bc => bc.CompanyType)
            .WithMany(c => c.CustomerCompanyTypes)
            .HasForeignKey(bc => bc.CompanyTypeId);

            modelBuilder.Entity<JobCategory>()
                .HasKey(x => new { x.JobId, x.CategoryId });

            modelBuilder.Entity<JobCategory>()
                .HasOne(bc => bc.Job)
                .WithMany(b => b.JobCategories)
                .HasForeignKey(bc => bc.JobId);
            modelBuilder.Entity<JobCategory>()
                .HasOne(bc => bc.Category)
                .WithMany(c => c.JobCategories)
                .HasForeignKey(bc => bc.CategoryId);
              
            modelBuilder.Entity<JobMachine>()
                    .HasKey(x => new { x.JobId, x.MachineId });

            modelBuilder.Entity<JobMachine>()
                .HasOne(bc => bc.Job)
                .WithMany(b => b.JobMachines)
                .HasForeignKey(bc => bc.JobId);
            modelBuilder.Entity<JobMachine>()
                .HasOne(bc => bc.Machine)
                .WithMany(c => c.JobMachines)
                .HasForeignKey(bc => bc.MachineId);

            modelBuilder.Entity<JobIndustry>()
                   .HasKey(x => new { x.JobId, x.IndustryId });

            modelBuilder.Entity<JobIndustry>()
                .HasOne(bc => bc.Job)
                .WithMany(b => b.JobIndustries)
                .HasForeignKey(bc => bc.JobId);
            modelBuilder.Entity<JobIndustry>()
                .HasOne(bc => bc.Industry)
                .WithMany(c => c.JobIndustries)
                .HasForeignKey(bc => bc.IndustryId);

            modelBuilder.Entity<JobFileType>()
                    .HasKey(x => new { x.JobId, x.FileTypeId });

            modelBuilder.Entity<JobFileType>()
                .HasOne(bc => bc.Job)
                .WithMany(b => b.JobFileTypes)
                .HasForeignKey(bc => bc.JobId);
            modelBuilder.Entity<JobFileType>()
                .HasOne(bc => bc.FileType)
                .WithMany(c => c.JobFileTypes)
                .HasForeignKey(bc => bc.FileTypeId);

            modelBuilder.Entity<JobMaterial>()
                    .HasKey(x => new { x.JobId, x.MaterialId });

            modelBuilder.Entity<JobMaterial>()
                .HasOne(bc => bc.Job)
                .WithMany(b => b.JobMaterials)
                .HasForeignKey(bc => bc.JobId);
            modelBuilder.Entity<JobMaterial>()
                .HasOne(bc => bc.Material)
                .WithMany(c => c.JobMaterials)
                .HasForeignKey(bc => bc.MaterialId);

            modelBuilder.Entity<JobCertification>()
                   .HasKey(x => new { x.JobId, x.CertificationId });

            modelBuilder.Entity<JobCertification>()
                .HasOne(bc => bc.Job)
                .WithMany(b => b.JobCertifications)
                .HasForeignKey(bc => bc.JobId);
            modelBuilder.Entity<JobCertification>()
                .HasOne(bc => bc.Certification)
                .WithMany(c => c.JobCertifications)
                .HasForeignKey(bc => bc.CertificationId);

            modelBuilder.Entity<JobCompanyType>()
             .HasKey(x => new { x.JobId, x.CompanyTypeId });

            modelBuilder.Entity<JobCompanyType>()
                .HasOne(bc => bc.Job)
                .WithMany(b => b.JobCompanyTypes)
                .HasForeignKey(bc => bc.JobId);
            modelBuilder.Entity<JobCompanyType>()
                .HasOne(bc => bc.CompanyType)
                .WithMany(c => c.JobCompanyTypes)
                .HasForeignKey(bc => bc.CompanyTypeId);


            // Partner Company Types
            modelBuilder.Entity<PartnerCompanyType>()
               .HasKey(x => new { x.PartnerId, x.CompanyTypeId });
            modelBuilder.Entity<PartnerCompanyType>()
                .HasOne(bc => bc.Partner)
                .WithMany(b => b.PartnerCompanyTypes)
                .HasForeignKey(bc => bc.PartnerId);

            modelBuilder.Entity<PartnerCompanyType>()
               .HasOne(bc => bc.CompanyType)
               .WithMany(c => c.PartnerCompanyTypes)
               .HasForeignKey(bc => bc.CompanyTypeId);

            //Job Questions
            modelBuilder.Entity<JobQuestion>()
                   .HasKey(x => new { x.JobId, x.QuestionId,x.BidderId });

            modelBuilder.Entity<JobQuestion>()
               .HasOne(bc => bc.Job)
               .WithMany(b => b.JobQuestions)
               .HasForeignKey(bc => bc.JobId);
            modelBuilder.Entity<JobQuestion>()
               .HasOne(bc => bc.Question)
               .WithMany(c => c.JobQuestions)
               .HasForeignKey(bc => bc.QuestionId);
            modelBuilder.Entity<JobQuestion>()
               .HasOne(bc => bc.Bidder)
               .WithMany(c => c.Questions)
               .HasForeignKey(bc => bc.BidderId);

            //JobBid
            modelBuilder.Entity<JobBid>()
                  .HasKey(x => new { x.JobId, x.BidderId });
            modelBuilder.Entity<JobBid>()
               .HasOne(bc => bc.Job)
               .WithMany(b => b.JobBids)
               .HasForeignKey(bc => bc.JobId);
            modelBuilder.Entity<JobBid>()
              .HasOne(bc => bc.Bidder)
              .WithMany(c => c.Bids)
              .HasForeignKey(bc => bc.BidderId);




        }

    }
}
