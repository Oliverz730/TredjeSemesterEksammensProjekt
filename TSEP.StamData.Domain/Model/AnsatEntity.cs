using System.ComponentModel.DataAnnotations;

namespace TSEP.StamData.Domain.Model
{
    public class AnsatEntity
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public virtual ICollection<KompetanceEntity> Kompetancer { get; private set; }
        public string UserId { get; private set; }
        [Timestamp]
        public byte[] RowVersion { get; private set; }
        
        public AnsatEntity(string userId, string name)
        {
            UserId = userId;
            Name = name;
        }
        //EF
        internal AnsatEntity() { }

        public void Edit(string userId,string name, ICollection<KompetanceEntity> kompetancer, byte[] rowVersion)
        {
            UserId = userId;
            Name = name;

            Kompetancer = kompetancer;
            RowVersion = rowVersion;
        }

    }
}
