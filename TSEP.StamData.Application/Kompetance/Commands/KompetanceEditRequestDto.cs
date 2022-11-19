namespace TSEP.StamData.Application.Kompetance.Commands
{
    public class KompetanceEditRequestDto
    {
        public string Description { get; set; }
        public ICollection<KompetanceAnsatEditRequestDto> Ansatte { get; set; }
    }
}
