namespace TSEP.App.Infrastructure.StamData.Contract.Dto
{
    public class KompetanceEditRequestDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        //public ICollection<KompetanceAnsatEditRequestDto> Ansatte { get; set; }
        public byte[] RowVersion { get; set; }

    }
}
