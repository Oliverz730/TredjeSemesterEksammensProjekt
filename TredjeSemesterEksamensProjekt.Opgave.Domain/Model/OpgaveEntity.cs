using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TredjeSemesterEksamensProjekt.Opgave.Domain.Model
{
    public class OpgaveEntity
    {
        public int Id { get; private set; }
        public TimeSpan Duration { get; private set; }
        public string Status { get; private set; }
        public KompetanceEntity Kompetance { get; private set; }
     
        public OpgaveEntity(TimeSpan duration, string status, KompetanceEntity kompetance)
        {
            Duration = duration;
            Status = status;
            Kompetance = kompetance;
        }

    }
}
