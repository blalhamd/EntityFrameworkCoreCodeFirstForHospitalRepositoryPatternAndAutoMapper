

using DomainModels.Entities;
using DomainModels.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MiddelLayer.EntitiesConfigurations
{
    public class BillConfiguration : IEntityTypeConfiguration<Bill>
    {
        public void Configure(EntityTypeBuilder<Bill> builder)
        {
            builder.ToTable("Bills").HasKey(x => x.Id);

            builder.Property(x => x.amount).HasPrecision(10, 2).IsRequired();
            builder.Property(x => x.dateTime).HasColumnType("date").IsRequired();
            builder.Property(x => x.status)
                                           .HasConversion(
                                               v => v.ToString(),
                                               v => (StatusBill)Enum.Parse(typeof(StatusBill), v)
                                           );

            builder.HasOne(x => x.patient)
                   .WithMany(x => x.Bills)
                   .HasForeignKey(x => x.patientId)
                   .IsRequired().OnDelete(DeleteBehavior.NoAction);


        }
    }
}
