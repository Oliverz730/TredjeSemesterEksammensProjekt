using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSEP.Igangsættelse.Application.Projekt.Commands
{
    public class ProjektEditRequestDto
    {
        public int Id { get; set; }
        public string ProjektName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string EstimatedTime { get; set; }
        public string ActualEstimated { get; set; }
        public string KundeUserId { get; set; }
        public Byte[] RowVersion { get; set; }
    }
}
