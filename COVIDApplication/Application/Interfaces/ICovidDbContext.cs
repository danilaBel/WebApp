using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ICovidDbContext
    {
        DbSet<Article> Articles { get; set; }
        DbSet<Comment> Comments { get; set; }
        DbSet<Republic> Republics { get; set; }
        DbSet<Statistic> Statistics { get; set; }
        DbSet<Virus> Viruses { get; set; }

        Task<int> SaveChanges(CancellationToken cn);
    }
}
