using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using MovieDatabase.Infra.Context;
using MovieDatabase.Infra.Entities;
using MovieDatabase.Infra.EntityTypeConfig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDatabase.Infra.Context
{
    internal class DbMovieContext : DbContext
    {

        public DbMovieContext(DbContextOptions<DbMovieContext> options) : base(options)
        {
            
        }

        public DbMovieContext()
        {
            
        }

        public DbSet<MovieEntity> Movies { get; set; }
        public DbSet<GenreEntity> Genres { get; set; }
        public DbSet<DirectorEntity> Directors { get; set; }
        public DbSet<ActorEntity> Actors { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MovieEntityTypeConfig).Assembly);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }


    }
}


public class DbContextFactory : IDesignTimeDbContextFactory<DbMovieContext>
{
    public DbMovieContext CreateDbContext(string[] args)
    {
        var basePath = Directory.GetCurrentDirectory(); // Geçerli çalışma dizinini al
        var config = new ConfigurationBuilder()
            .SetBasePath(basePath) // appsettings.json dosyasını bulabilmesi için base path ekle
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

        var connStr = config.GetConnectionString("dockerConnection");

        var optionsBuilder = new DbContextOptionsBuilder<DbMovieContext>();
        optionsBuilder.UseSqlServer(connStr); // Bağlantıyı kullan

        return new DbMovieContext(optionsBuilder.Options); // Yeni bir DbContext örneği döndür
    }
}
