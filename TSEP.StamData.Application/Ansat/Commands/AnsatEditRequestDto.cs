namespace TSEP.StamData.Application.Ansat.Commands
{
    public class AnsatEditRequestDto
    {
        public string UserId { get; set; }
        public string Name { get; set; }

        public byte[] RowVersion { get; set; }
        public ICollection<AnsatKompetanceEditRequestDto> Kompetancer { get; set; }

    }
}
