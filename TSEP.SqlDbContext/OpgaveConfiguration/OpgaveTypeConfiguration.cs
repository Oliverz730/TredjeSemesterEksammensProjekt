using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TSEP.Igangsættelse.Domain.Model;

namespace TSEP.SqlDbContext.OpgaveConfiguration
{
    public class OpgaveTypeConfiguration : IEntityTypeConfiguration<OpgaveTypeEntity>
    {
        public void Configure(EntityTypeBuilder<OpgaveTypeEntity> builder)
        {
            builder.ToTable("OpgaveType", "opgaveType");

            builder.HasKey(x => x.Id);
        }
    }
}
