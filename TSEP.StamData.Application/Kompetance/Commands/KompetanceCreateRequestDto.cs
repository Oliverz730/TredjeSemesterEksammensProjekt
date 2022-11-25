namespace TSEP.StamData.Application.Kompetance.Commands
{
    public class KompetanceCreateRequestDto
    {
        public string Description { get; set; }

        public byte[] RowVersion { get; set; }
    }
}