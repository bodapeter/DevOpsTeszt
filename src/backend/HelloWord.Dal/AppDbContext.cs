using HelloWord.Bll.Models;
using HelloWord.Dal.EntityConfiguration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWord.Dal
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Greeting> Greetings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new GreetingConfiguration());

            modelBuilder.Entity<Greeting>().HasData(new object[] {
                new 
                {
                    Id=1,
                    Name = "Peti",
                    TimeStamp = new DateTime(2020, 11, 20, 15, 30, 0)
                },
                new 
                {
                    Id=2,
                    Name = "Tomi",
                    TimeStamp = new DateTime(2020, 11, 20, 15, 30, 10)
                }

            });
        }
    }
}
