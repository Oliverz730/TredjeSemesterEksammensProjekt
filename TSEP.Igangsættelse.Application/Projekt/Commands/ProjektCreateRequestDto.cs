
namespace TSEP.Igangsættelse.Application.Projekt.Commands
{
    public class ProjektCreateRequestDto
    {
        public string ProjektName { get; set; }
        public DateTime StartDate { get;  set; }
        public string SælgerUserId { get;  set; }
        public string KundeUserId { get;  set; }
        //Create har ikke en RowVersion, da det kun kræves på handlinger på eksisterende rækker i databasen
    }
}
