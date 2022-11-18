namespace TredjeSemesterEksammensProjekt.Infrastructure.Contract.Dto
{
    public class KompetanceEditRequestDto
    {
        public string Description { get; set; }
        public ICollection<KompetanceAnsatEditRequestDto> Ansatte { get; set; }
    }
}
