using Microsoft.EntityFrameworkCore;
using TSEP.StamData.Domain.Model;
using TSEP.Igangsættelse.Domain.Model;
using TSEP.Kalender.Domain.Model;
using TSEP.SqlDbContext.StamDataConfiguration;
using TSEP.SqlDbContext.IgangsættelseConfiguration;
using TSEP.SqlDbContext.KalenderConfiguration;


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
        public DbSet<OpgaveEntity> OpgaveEntities { get; set; }
        public DbSet<BookingEntity> BookingEntities { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .ApplyConfiguration(new KompetanceTypeConfiguration())
                .ApplyConfiguration(new AnsatTypeConfiguration())

                .ApplyConfiguration(new OpgaveTypeConfiguration())
                .ApplyConfiguration(new ProjektConfuguration())

                .ApplyConfiguration(new OpgaveConfuguration())
                .ApplyConfiguration(new BookingConfiguration())
                ;
        }
    }
}
