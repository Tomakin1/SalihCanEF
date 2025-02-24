
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
    public class BaseEntityTypeConfig<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasKey(e => e.Id); // BaseEntity'den miras alan bütün tablolardaki Idler Keydir
            builder.Property(e => e.CreatedDate)
                .HasColumnType("datetime2"); //veritabanı için özellikle bir tip istiyorsan kullanılır
              //.HasDefaultValue(DateTime.Now) // default value c# dilinde verilebilir
              //.HasDefaultValueSql("getdate()"); //default value sql için verilebilir

            //builder.Property(e => e.Id)
            //    .HasColumnName("id"); // Modelde Id yaptığımız Id'yi db'de id olarak kaydet

            builder.Property(e => e.ModifiedDate)
                .HasColumnType("datetime2")
                .IsRequired(false); // veritabanında değer null olabilir demek
        }
    }
}
