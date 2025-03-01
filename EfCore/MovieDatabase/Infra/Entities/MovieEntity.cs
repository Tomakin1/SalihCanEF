﻿using MovieDatabase.Infra.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDatabase.Infra.Entities
{
    public class MovieEntity : BaseEntity
    {
        public string Name { get; set; }
        public int ViewCount { get; set; }

        public int GenreId { get; set; }
        public int DirectorId { get; set; }

        public virtual GenreEntity Genre { get; set; }
        public virtual DirectorEntity Director { get; set; }
        public virtual ICollection<ActorEntity> Actors { get; set; }
    }
}
