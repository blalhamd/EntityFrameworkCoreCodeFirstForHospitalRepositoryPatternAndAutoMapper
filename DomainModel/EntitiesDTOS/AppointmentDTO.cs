

using DomainModels.Enums;

namespace DomainModels.EntitiesDTOS
{
    public class AppointmentDTO
    {
        public DateTime dateTime { get; set; }
        public StatusAppointment status { get; set; }
        public int patientId { get; set; }
        public int doctorId { get; set; }
    }
}
