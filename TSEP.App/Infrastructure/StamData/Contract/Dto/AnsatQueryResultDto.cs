namespace TSEP.App.Infrastructure.StamData.Contract.Dto
{
    public class AnsatQueryResultDto
    {
        public string Name { get; set; }
        public ICollection<AnsatKompetanceQueryResultDto> Kompetancer { get; set; }

        public string UserId { get; set; }
        public byte[] RowVersion { get; set; }

    }
}
