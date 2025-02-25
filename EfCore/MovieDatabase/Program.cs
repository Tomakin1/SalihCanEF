using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MovieDatabase.Infra.Context;
using MovieDatabase.Infra.DataGenerators;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;



var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
var connStr = config.GetConnectionString("dockerConnection");

var optionsBuilder = new DbContextOptionsBuilder<DbMovieContext>();
optionsBuilder.UseSqlServer(connStr);


var dbContext = new DbMovieContext(optionsBuilder.Options);
await EnsureMigrations();
  EnsureMovieData();

async Task EnsureMigrations()
{
    //var hasPendingChanges = dbContext.Database.GetPendingMigrationsAsync(); // herhangi bir bekleyen işlem veriyor
    var migrations = await dbContext.Database.GetPendingMigrationsAsync(); // bekleyen migrationsları veriyor

    if (migrations.Any())
    {
        Console.WriteLine("Migrations Applying");

        //var reqmiq = migrations
        //    //.FirstOrDefault(i => i.Contains("REMOVE"))
        //    .Last();

        await dbContext.Database.MigrateAsync();
        Console.WriteLine("Migrations Apllied");

    }

}



async Task EnsureMovieData()
{
    var MovieExist = await dbContext.Movies.AnyAsync();

    if (MovieExist)
        return;

    var movies = DataGenerators.GenerateMovies(10);
    dbContext.Movies.AddRange(movies);
    dbContext.SaveChanges();
    Console.WriteLine("Movies added : 10");
        
    
}
