namespace TSEP.App.Infrastructure.Contract.Dto
{
    public class KompetanceEditRequestDto
    {
        public string Description { get; set; }
        public ICollection<KompetanceAnsatEditRequestDto> Ansatte { get; set; }
        public byte[] RowVersion { get; set; }

    }
}
