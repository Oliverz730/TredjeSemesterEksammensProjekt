using Microsoft.EntityFrameworkCore;
using TSEP.SqlDbContext.OpgaveConfiguration;
using TSEP.StamData.Domain.Model;

namespace TSEP.SqlDbContext
{
    public class TredjeSemesterEksamensProjektContext : DbContext
    {
        public TredjeSemesterEksamensProjektContext(DbContextOptions<TredjeSemesterEksamensProjektContext> options) : base(options)
        {

        }

        public DbSet<KompetanceEntity> KompetanceEntities { get; set; }
        public DbSet<OpgaveEntity> OpgaveEntities { get; set; }
        public DbSet<AnsatEntity> AnsatEntities { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .ApplyConfiguration(new OpgaveTypeConfiguration())
                .ApplyConfiguration(new KompetanceTypeConfiguration())
                .ApplyConfiguration(new AnsatTypeConfiguration())
                ;
        }
    }
}
