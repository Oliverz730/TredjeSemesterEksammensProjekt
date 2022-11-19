namespace TSEP.App.Infrastructure.Contract.Dto
{
    public class AnsatEditRequestDto
    {
        public string UserId { get; set; }
        public string Name { get; set; }
        public ICollection<AnsatKompetanceEditRequestDto> Kompetancer { get; set; }
    }
}
