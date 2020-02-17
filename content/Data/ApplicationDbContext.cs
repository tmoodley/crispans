using System;
using System.Collections.Generic;
using System.Text;
using HelpingHands.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Vue2Spa.Models;

namespace HelpingHands.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Dependent> Dependents { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Partner> Partners { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Naics> Naics { get; set; }
        public DbSet<Capability> Capabilities { get; set; }
        public DbSet<Machine> Machines { get; set; }
        public DbSet<Industry> Industries { get; set; }
        public DbSet<FileType> FileTypes { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<Certification> Certifications { get; set; }
        public DbSet<CompanyType> CompanyTypes { get; set; }
    }
}
