namespace TSEP.App.Infrastructure.Igangsættelse.Contract.Dto
{
    public class ProjektCreateRequestDto
    {
        public string ProjektName { get; set; }
        public DateTime StartDate { get; set; }
        public string SælgerUserId { get; set; }
        public string KundeUserId { get; set; }
    }
}
