using Domain.Entity;
using Infrastructure_;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Test
{
    public static class AppDbContextFactory
    {
        public static AppDBContext Create()
        {
            var options = new DbContextOptionsBuilder<AppDBContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var context = new AppDBContext(options);

            context.Database.EnsureCreated();


            return context;
        }

        public static void Destroy(AppDBContext context)
        {
            context.Database.EnsureDeleted();

            context.Dispose();
        }
    }
}
