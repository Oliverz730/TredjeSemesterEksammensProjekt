using System.ComponentModel.DataAnnotations;

namespace TSEP.StamData.Domain.Model
{
    public class KompetanceEntity
    {
        public int Id{ get; set; }
        public string Description { get; private set; }

        public virtual ICollection<AnsatEntity> Ansatte { get; private set; }
        [Timestamp]
        public byte[] RowVersion { get; set; }

        public KompetanceEntity(string description, ICollection<AnsatEntity> ansatte, byte[] rowVersion)
        {
            Description = description;
            Ansatte = ansatte;
            RowVersion = rowVersion;
        }

        public KompetanceEntity(string description, byte[] rowVersion)
        {
            Description = description;
            RowVersion = rowVersion;
        }
        //EF
        internal KompetanceEntity()
        {
        }
    }
}
