namespace TSEP.StamData.Domain.Model
{
    public class AnsatEntity
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public virtual ICollection<KompetanceEntity> Kompetancer { get; private set; }
        
        public string UserId { get; private set; }

        public AnsatEntity(ICollection<KompetanceEntity> kompetancer, string userId, string name)
        {
            Kompetancer = kompetancer;
            UserId = userId;
            Name = name;
        }

        public AnsatEntity(string userId, string name)
        {
            UserId = userId;
            Name = name;
        }

        internal AnsatEntity()
        {
        }

        public void Edit(string userId,string name, ICollection<KompetanceEntity> kompetancer)
        {
            UserId = userId;
            Name = name;

            Kompetancer = kompetancer;
        }

    }
}
