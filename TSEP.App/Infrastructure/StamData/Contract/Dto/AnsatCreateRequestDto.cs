namespace TSEP.App.Infrastructure.StamData.Contract.Dto
{
    public class AnsatCreateRequestDto
    {
        public string Name { get; set; }
        public string UserId { get; set; }
        public byte[] RowVersion { get;  set; }

    }
}
