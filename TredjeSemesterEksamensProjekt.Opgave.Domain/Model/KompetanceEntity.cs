using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TredjeSemesterEksamensProjekt.Opgave.Domain.Model
{
    public class KompetanceEntity
    {
        public int Id{ get; set; }
        public string Description { get; private set; }

        public ICollection<AnsatEntity> Ansatte { get; private set; }

        public KompetanceEntity(string description, ICollection<AnsatEntity> ansatte)
        {
            Description = description;
            Ansatte = ansatte;
        }

        public KompetanceEntity(string description)
        {
            Description = description;
        }

        internal KompetanceEntity()
        {
        }
    }
}
