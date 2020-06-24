using Application.Interfaces;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Persistance
{
    public class DBContextEntity:DbContext,ICovidDbContext
    {
        public DBContextEntity(DbContextOptions<DBContextEntity> options):base(options)
        {
                
        }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Republic> Republics { get; set; }
        public DbSet<Statistic> Statistics { get; set; }
        public DbSet<Virus> Viruses { get; set; }

        public Task<int> SaveChanges(CancellationToken cn)
        {
            return base.SaveChangesAsync(cn);
        }
    }
}
