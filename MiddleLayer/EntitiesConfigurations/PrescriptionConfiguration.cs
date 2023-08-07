

using DomainModels.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MiddelLayer.EntitiesConfigurations
{
    public class PrescriptionConfiguration : IEntityTypeConfiguration<Prescription>
    {
        public void Configure(EntityTypeBuilder<Prescription> builder)
        {
            builder.ToTable("Prescriptions").HasKey(x => x.Id);

            builder.Property(x => x.dosage).HasColumnType("varchar").HasMaxLength(256).IsRequired(false);
            builder.Property(x => x.frequency).IsRequired();
            builder.Property(x => x.duration).HasColumnType("varchar").HasMaxLength(256).IsRequired();
            builder.Property(x => x.medication).HasColumnType("varchar").HasMaxLength(256).IsRequired();

            builder.HasOne(x => x.appointment)
                   .WithMany(x => x.prescriptions)
                   .HasForeignKey(x => x.AppointmentId)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
