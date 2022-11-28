namespace TSEP.StamData.Application.Kompetance.Commands
{
    public class KompetanceCreateRequestDto
    {
        public string Description { get; set; }
        //Create har ikke en RowVersion, da det kun kræves på handlinger på eksisterende rækker i databasen
    }
}