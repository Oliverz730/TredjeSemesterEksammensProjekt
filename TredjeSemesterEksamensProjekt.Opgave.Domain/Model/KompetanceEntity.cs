using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TredjeSemesterEksamensProjekt.Opgave.Domain.Model
{
    public class KompetanceEntity
    {
        public string Description { get; private set; }

        public KompetanceEntity(string description)
        {
            Description = description;
        }
    }
}
