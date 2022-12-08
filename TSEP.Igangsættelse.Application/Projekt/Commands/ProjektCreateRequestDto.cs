using System;
using System.Collections.Generic;
using System.Linq;
namespace TSEP.Igangsættelse.Application.Projekt.Commands
{
    public class ProjektCreateRequestDto
    {
        public string ProjektName { get; set; }
        public DateTime StartDate { get;  set; }
        public string SælgerUserId { get;  set; }
        public string KundeUserId { get;  set; }
    }
}
