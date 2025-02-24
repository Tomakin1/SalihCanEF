using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieDatabase.Infra.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDatabase.Infra.EntityTypeConfig
{
    internal class MovieEntityTypeConfig : BaseEntityTypeConfig<MovieEntity>
    {

        public override void Configure(EntityTypeBuilder<MovieEntity> builder)
        {
            builder.Property(m=>m.Name).IsRequired().HasMaxLength(50);
            builder.Property(m => m.ViewCount).HasDefaultValue(1);


            // One-To-Many Genre Entity
            builder.HasOne(m => m.Genre)
                .WithMany(g => g.Movies)
                .HasForeignKey(m => m.GenreId);

            // One-To-Many Director Entity
            builder.HasOne(m=>m.Director)
                .WithMany(d=>d.Movies)
                .HasForeignKey(m => m.DirectorId);

            // Many-To-Many Actor Entity
            builder.HasMany(m => m.Actors)
                .WithMany(a => a.Movies)
                .UsingEntity(m => m.ToTable("MovieActors"));
                






            base.Configure(builder);
        }
    }
}
