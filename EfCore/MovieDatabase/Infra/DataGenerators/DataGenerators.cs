using Bogus;
using MovieDatabase.Infra.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDatabase.Infra.DataGenerators
{
    internal abstract class DataGenerators
    {
        public static List<MovieEntity> GenerateMovies(int count)
        {
            var locale = "tr";

            var genreFaker = new Faker<GenreEntity>(locale)
                    .RuleFor(g => g.Id, f => f.Random.Int())
                    .RuleFor(g => g.CreatedDate, f => f.Date.Past(5))
                    .RuleFor(g => g.ModifiedDate, f => f.Date.Past(2))
                    .RuleFor(g => g.Name, f => f.Commerce.Categories(1).First());

            var DirectorFaker = new Faker<DirectorEntity>(locale)
                    .RuleFor(d => d.Id, f => f.Random.Int())
                    .RuleFor(d => d.CreatedDate, f => f.Date.Past(5))
                    .RuleFor(d => d.ModifiedDate, f => f.Date.Past(2))
                    .RuleFor(d => d.Firstname, f => f.Name.FirstName())
                    .RuleFor(d => d.Lastname, f => f.Name.LastName());

            var ActorFaker = new Faker<ActorEntity>(locale)
                     .RuleFor(a => a.Id, f => f.Random.Int())
                     .RuleFor(a => a.CreatedDate, f => f.Date.Past(5))
                     .RuleFor(a => a.ModifiedDate, f => f.Date.Past(2))
                     .RuleFor(a => a.Firstname, f => f.Name.FirstName())
                     .RuleFor(a => a.Lastname, f => f.Name.LastName())
                     .RuleFor(a => a.Movies, f => []);

            var genres = genreFaker.Generate(5);
            var directors = DirectorFaker.Generate(5);
            var actors = ActorFaker.Generate(20);


            var MovieFaker = new Faker<MovieEntity>(locale)
               .RuleFor(m => m.Id, f => f.Random.Int())
               .RuleFor(m => m.CreatedDate, f => f.Date.Past(5))
               .RuleFor(m => m.ModifiedDate, f => f.Date.Past(2))
               .RuleFor(m => m.Name, f => f.Lorem.Sentence(3))
               .RuleFor(m => m.DirectorId, f => f.PickRandom(directors).Id)
               .RuleFor(m => m.GenreId, f => f.PickRandom(genres).Id)
               .RuleFor(m => m.Director, f => f.PickRandom(directors))
               .RuleFor(m => m.Genre, f => f.PickRandom(genres))
               .RuleFor(m => m.Actors, f => f.PickRandom(actors, f.Random.Int(2, 5)).ToList());


                    var movies = MovieFaker.Generate(count);
                    return movies;




        }
    }
}
