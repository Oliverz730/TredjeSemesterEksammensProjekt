using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSEP.Igangsættelse.Application.Projekt.Queries
{
    public class ProjektQueryResultDto
    {
        public int Id { get; set; }
        public string ProjektName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? EstimatedTime { get; set; }
        public string? ActualEstimated { get; set; }
        public string SælgerUserId { get; set; }
        public string KundeUserId { get; set; }
        public byte[] RowVersion { get; set; }
    }
}
