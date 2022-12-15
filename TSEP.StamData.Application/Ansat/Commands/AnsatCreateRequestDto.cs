namespace TSEP.StamData.Application.Ansat.Commands
{
    public class AnsatCreateRequestDto
    {
        public string UserId { get; set; }
        public string Name { get; set; }
        //Create har ikke en RowVersion, da det kun kræves på handlinger på eksisterende rækker i databasen
    }
}
