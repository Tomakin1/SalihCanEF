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
    internal class ActorEntityTypeConfig : BaseEntityTypeConfig<ActorEntity>
    {
        public override void Configure(EntityTypeBuilder<ActorEntity> builder)
        {

            builder.Property(a => a.EmailAddress).IsRequired().HasMaxLength(50);
            builder.Property(a => a.Vallet).HasDefaultValue(1000).IsRequired();

            base.Configure(builder);
        }
    }
}
