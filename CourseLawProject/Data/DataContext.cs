using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Text.Json;
using System.Threading.Tasks;
using System.IO;
using CourseLawProject.Data.Entities;

namespace CourseLawProject.Data
{
    public class DataContext:DbContext
    {
        public DbSet<Entities.User> Users { get; set; }
        public DbSet<Entities.Admin> Admins { get; set; }
        public DbSet<Entities.Client> Clients { get; set; }
        public DbSet<Entities.Individual> Individuals { get; set; }
        public DbSet<Entities.LegalEntity> LegalEntities { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = JsonSerializer.Deserialize<JsonNode>(
            File.ReadAllText("appconfig.json"));

            optionsBuilder.UseMySql(
            config["databases"]["planetScale"]["connectionString"].ToString(),
            new MySqlServerVersion(new Version(8, 0, 34))
            );
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Entities.LegalEntity>()
                .Property(e => e.OrganizationForm)
                .HasConversion<string>();

            modelBuilder.Entity<Entities.User>().ToTable("Users");
            modelBuilder.Entity<Entities.Admin>().ToTable("Admins");
            modelBuilder.Entity<Entities.Client>().ToTable("Clients");
            modelBuilder.Entity<Entities.Individual>().ToTable("Individuals");
            modelBuilder.Entity<Entities.LegalEntity>().ToTable("LegalEntities");

        }
    }
}
