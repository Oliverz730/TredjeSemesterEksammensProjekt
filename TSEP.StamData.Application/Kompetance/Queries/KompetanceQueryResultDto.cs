namespace TSEP.StamData.Application.Kompetance.Queries
{
    public class KompetanceQueryResultDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public byte[] RowVersion { get; set; }

        //public ICollection<KompetanceAnsatQueryResultDto> Ansatte { get; set; }
    }
}
