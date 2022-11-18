namespace TredjeSemesterEksamensProjekt.StamData.Application.Commands
{
    public class AnsatEditRequestDto
    {
        public string UserId { get; set; }
        public string Name { get; set; }

        public ICollection<AnsatKompetanceEditRequestDto> Kompetancer { get; set; }

    }
}
