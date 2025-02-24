



using Microsoft.EntityFrameworkCore;
using MovieDatabase.Infra.Context;

var dbContext = new DbMovieContext();
dbContext.Database.OpenConnection();

Console.ReadLine();