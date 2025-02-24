﻿using MovieDatabase.Infra.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDatabase.Infra.Entities
{
    public class ActorEntity : PersonEntity
    {
        public virtual  ICollection<MovieEntity>Movies { get; set; }
    }
}
