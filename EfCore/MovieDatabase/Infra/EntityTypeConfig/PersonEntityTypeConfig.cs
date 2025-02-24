using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieDatabase.Infra.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDatabase.Infra.EntityTypeConfig
{
    public class PersonEntityTypeConfig<TEntity> : BaseEntityTypeConfig<TEntity> where TEntity : PersonEntity
    {
        public override void Configure(EntityTypeBuilder<TEntity> builder)
        {

            builder.Property(e => e.Firstname)
                .HasMaxLength(50).IsRequired();

            builder.Property(e => e.Lastname)
                .HasMaxLength(50).IsRequired();

            base.Configure(builder);
        }
    }
}
