using AutomatedTellerMachine.Migrations;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AutomatedTellerMachine.Models
{
    public interface IApplicationDbContext
    {
         IDbSet<CheckingAccount> CheckingAccounts { get; set; }
         DbSet<GameInfo> GamesInfos { get; set; }
         DbSet<NewsModel> NewsModels { get; set; }
       //  DbSet<ApplicationUser> ApplicationUsers { get; set; }

        int SaveChanges();
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IApplicationDbContext
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDbContext, Configuration>());
            base.OnModelCreating(modelBuilder);
        }

        public IDbSet<CheckingAccount> CheckingAccounts { get; set; }
        public DbSet<GameInfo> GamesInfos { get; set; }
        public DbSet<NewsModel> NewsModels { get; set; }
       // public DbSet<ApplicationUser> ApplicationUsers { get; set; }
    }

}