

using DomainModels.Entities;
using DomainModels.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MiddelLayer.EntitiesConfigurations
{
    public class AppoinmentConfiguration : IEntityTypeConfiguration<Appointment>
    {
        public void Configure(EntityTypeBuilder<Appointment> builder)
        {
            builder.ToTable("Appointments").HasKey(x => x.Id);

            builder.Property(x => x.dateTime).HasColumnType("date").IsRequired();
            builder.Property(x => x.status)
                                           .HasConversion(
                                               v => v.ToString(),
                                               v => (StatusAppointment)Enum.Parse(typeof(StatusAppointment), v)
                                           );

            builder.HasOne(x => x.patient)
                   .WithMany(x => x.appointments)
                   .HasForeignKey(x => x.patientId)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.doctor)
                   .WithMany(x => x.appointments)
                   .HasForeignKey(x => x.doctorId)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
