using CryptoSimulation.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CryptoSimulation.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<Portfolio> Portfolio{ get; set; }
        public DbSet<Transaction> Transaction { get; set; }
        public DbSet<Wallet> Wallet { get; set; }
        public DbSet<WalletPart> WalletPart { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<ApplicationUser>().ToTable("ApplicationUser");
            builder.Entity<Portfolio>().ToTable("Portfolio");
            builder.Entity<Transaction>().ToTable("Transaction");
            builder.Entity<Wallet>().ToTable("Wallet");
            builder.Entity<WalletPart>().ToTable("WalletPart");
            //foreach (var foreignKey in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            //{
            //    foreignKey.DeleteBehavior = DeleteBehavior.SetNull;
            //}
            builder.Entity<Transaction>().
                HasOne(x => x.WalletReciever).WithMany().HasForeignKey(x => x.WalletIDReciever).OnDelete(DeleteBehavior.ClientCascade);
            builder.Entity<Transaction>().
                HasOne(x => x.WalletSender).WithMany().HasForeignKey(x => x.WalletIDSender).OnDelete(DeleteBehavior.ClientCascade);
        }
    }
}
