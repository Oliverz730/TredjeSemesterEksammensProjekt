using System;
using System.Collections.Generic;
using System.Linq;
namespace TSEP.Igangsættelse.Application.Projekt.Commands
{
    public class ProjektCreateRequestDto
    {
        public DateTime StartDate { get;  set; }
        public DateTime EndDate { get;  set; }
        public string EstimatedTime { get;  set; }
        public string ActualEstimated { get;  set; }
        public string SælgerUserId { get;  set; }
        public string KundeUserId { get;  set; }
    }
}
