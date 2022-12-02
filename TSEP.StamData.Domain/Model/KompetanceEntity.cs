using System.ComponentModel.DataAnnotations;

namespace TSEP.StamData.Domain.Model
{
    public class KompetanceEntity
    {
        public int Id{ get; set; }
        public string Description { get; private set; }

        public virtual ICollection<AnsatEntity> Ansatte { get; private set; }
        //Hvis Timestamp (RowVersion) tabes under roundtrip, vil man ikke få lov til at edit.
        [Timestamp] 
        public byte[] RowVersion { get; set; }

        //public void Edit(string description, ICollection<AnsatEntity> ansatte, byte[] rowVersion)
        //{
        //    Description = description;
        //    Ansatte = ansatte;
        //    RowVersion = rowVersion;
        //}
        public void Edit(string description, byte[] rowVersion)
        {
            Description = description;
            RowVersion = rowVersion;
        }

        public KompetanceEntity(string description)
        {
            Description = description;
        }
        //EF
        internal KompetanceEntity() { }
    }
}
