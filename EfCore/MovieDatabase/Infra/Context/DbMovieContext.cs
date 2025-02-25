using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
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
    public class DbMovieContext : DbContext
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
            modelBuilder.HasDefaultSchema("dbo");
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

        var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        var connStr = config.GetConnectionString("dockerConnection");

        var optionsBuilder = new DbContextOptionsBuilder<DbMovieContext>();
        optionsBuilder.UseSqlServer(connStr);

        return new DbMovieContext(optionsBuilder.Options);
    }
}
                    








