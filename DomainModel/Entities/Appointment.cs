

using DomainModels.Enums;

namespace DomainModels.Entities
{
    public class Appointment
    {
        public int Id { get; set; }
        public DateTime dateTime { get; set; }
        public StatusAppointment status { get; set; }
        public int patientId { get; set; }
        public Patient patient { get; set; }
        public int doctorId { get; set; }
        public Doctor doctor { get; set; }
        public ICollection<Prescription> prescriptions { get; set; } = new List<Prescription>();

    }
}
