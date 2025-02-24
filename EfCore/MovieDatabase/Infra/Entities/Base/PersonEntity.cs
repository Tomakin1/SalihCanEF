using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDatabase.Infra.Entities.Base
{
    public class PersonEntity : BaseEntity
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
    }
}
