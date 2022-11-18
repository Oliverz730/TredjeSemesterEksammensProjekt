namespace TSEP.StamData.Domain.Model
{
    public class KompetanceEntity
    {
        public int Id{ get; set; }
        public string Description { get; private set; }

        public virtual ICollection<AnsatEntity> Ansatte { get; private set; }

        public KompetanceEntity(string description, ICollection<AnsatEntity> ansatte)
        {
            Description = description;
            Ansatte = ansatte;
        }

        public KompetanceEntity(string description)
        {
            Description = description;
        }

        internal KompetanceEntity()
        {
        }
    }
}
