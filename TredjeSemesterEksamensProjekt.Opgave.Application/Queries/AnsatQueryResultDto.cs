namespace TredjeSemesterEksamensProjekt.StamData.Application.Queries
{
    public class AnsatQueryResultDto
    {
        public string Name { get; set; }
        public ICollection<AnsatKompetanceQueryResultDto> Kompetancer { get; set; }

        public string UserId { get; set; }
    }
}
