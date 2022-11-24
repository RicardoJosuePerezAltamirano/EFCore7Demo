using ConsoleDemo.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDemo
{
    public class ContextDemo : DbContext
    {
        public ContextDemo()
        {

        }
        public DbSet<Trademark> Trademarks { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=ROOT-DEVICE;Initial Catalog=DataDiagnostics;Integrated Security=true;Encrypt=False");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Trademark>().HasKey(o => o.Id);
            modelBuilder.Entity<Model>().HasKey(o => o.Id);
            modelBuilder.Entity<Model>()
                .InsertUsingStoredProcedure("InsertModel", o =>
                {
                    o.HasParameter("Name");
                    o.HasResultColumn("Id");
                });
            modelBuilder.Entity<Model>()
                .UpdateUsingStoredProcedure("UpdateModel", o =>
                {
                    o.HasParameter("Name");
                    o.HasOriginalValueParameter("Id");
                    o.HasRowsAffectedResultColumn();
                });



            modelBuilder.Entity<Vehicle>()
                .HasKey(o => o.Id);
            modelBuilder.Entity<Vehicle>(o => o.HasOne(o => o.Trademark).WithMany(o => o.Vehicles));
            modelBuilder.Entity<Vehicle>(o => o.HasOne(o => o.Model).WithMany(o => o.Vehicles));


            base.OnModelCreating(modelBuilder);
        }

    }
}
