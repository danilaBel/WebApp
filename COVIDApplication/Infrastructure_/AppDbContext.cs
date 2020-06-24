using Application.Interfaces;
using Domain.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Math.EC.Rfc7748;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure_
{
    public class AppDBContext : IdentityDbContext<AppUser, IdentityRole,string>, ICovidDbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Republic> Republics { get; set; }
        public DbSet<Statistic> Statistics { get; set; }
        public DbSet<Virus> Viruses { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
            .Entity<AppUser>()
            .Property(e => e.Id)
            .ValueGeneratedOnAdd();

            builder.Entity<Article>().Property(e => e.Id).ValueGeneratedOnAdd();
            builder.Entity<Comment>().Property(e => e.id).ValueGeneratedOnAdd();
            builder.Entity<Virus>().Property(e => e.Id).ValueGeneratedOnAdd();

            builder.Entity<Comment>()
            .HasOne(x => x.From)
            .WithMany();

            builder.Entity<Comment>()
            .HasOne(x => x.ArticleTo)
            .WithMany();

            builder.Entity<Article>()
            .HasOne(x => x.AppUser)
            .WithMany();

           

            builder.Entity<Statistic>()
            .HasOne(x => x.Virus)
            .WithOne();
           
            base.OnModelCreating(builder);
        }
            public Task<int> SaveChanges(CancellationToken cn)
        {
            return base.SaveChangesAsync(cn);
        }

    }
}
