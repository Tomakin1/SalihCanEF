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
    public class GenreEntityConfig : BaseEntityTypeConfig<GenreEntity>
    {
        public override void Configure(EntityTypeBuilder<GenreEntity> builder)
        {

            builder.ToTable(name: "Genres"); // GenreEntity db'de tablo ado "Genres" ŞEMASI "EF"
            builder.Property(a => a.Name).HasColumnName("Name")// GenreEntity tablosunda name sütunu Name olarak kayıt edilsin
                    .IsRequired() //doldurulması zorunlu olsun (false yazılmadıysa true döner)
                    .HasMaxLength(50); //sütunun max lengthi 50 olsun




            base.Configure(builder); // base entity configlerini otomatik alır
        }

    }
}




































