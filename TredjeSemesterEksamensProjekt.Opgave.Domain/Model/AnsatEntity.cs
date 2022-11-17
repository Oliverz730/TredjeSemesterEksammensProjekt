using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TredjeSemesterEksamensProjekt.Opgave.Domain.Model
{
    public class AnsatEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<KompetanceEntity> Kompetancer { get; private set; }
        
        public string UserId { get; private set; }

        public AnsatEntity(ICollection<KompetanceEntity> kompetancer, string userId, string name)
        {
            Kompetancer = kompetancer;
            UserId = userId;
            Name = name;
        }

        public AnsatEntity(string userId, string name)
        {
            UserId = userId;
            Name = name;
        }

        internal AnsatEntity()
        {
        }

    }
}
