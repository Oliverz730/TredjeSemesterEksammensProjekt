using Microsoft.EntityFrameworkCore;
using TSEP.SqlDbContext.OpgaveConfiguration;
using TSEP.StamData.Domain.Model;
using TSEP.Igangsættelse.Domain.Model;


namespace TSEP.SqlDbContext
{
    public class TredjeSemesterEksamensProjektContext : DbContext
    {
        public TredjeSemesterEksamensProjektContext(DbContextOptions<TredjeSemesterEksamensProjektContext> options) : base(options)
        {

        }

        public DbSet<KompetanceEntity> KompetanceEntities { get; set; }
        public DbSet<OpgaveTypeEntity> OpgaveTypeEntities { get; set; }
        public DbSet<AnsatEntity> AnsatEntities { get; set; }
        public DbSet<ProjektEntity> ProjektEntities { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .ApplyConfiguration(new OpgaveTypeConfiguration())
                .ApplyConfiguration(new KompetanceTypeConfiguration())
                .ApplyConfiguration(new AnsatTypeConfiguration())
                .ApplyConfiguration(new ProjektConfuguration())
                ;
        }
    }
}
