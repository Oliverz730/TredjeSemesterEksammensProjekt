namespace TSEP.StamData.Application.Ansat.Commands
{
    public class AnsatCreateRequestDto
    {
        public string UserId { get; set; }
        public string Name { get; set; }

        public byte[] RowVersion { get; set; }
    }
}
