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
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public string Status { get; private set; }
        public KompetanceEntity Kompetance { get; private set; }
     
        public OpgaveEntity(DateTime startDate, DateTime endDate, string status, KompetanceEntity kompetance, int id)
        {
            StartDate = startDate;
            EndDate = endDate;
            Status = status;
            Kompetance = kompetance;
            Id = id;
        }
        internal OpgaveEntity()
        {   
        }

    }
}
