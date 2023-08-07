

namespace DomainModels.Entities
{
    public class Prescription
    {
        public int Id { get; set; }
        public string medication { get; set; }
        public string? dosage { get; set; }
        public int frequency { get; set; }   // The frequency of taking the medication prescribed
        public string duration { get; set; } //The duration of taking the medication prescribed
        public int AppointmentId { get; set; }
        public Appointment appointment { get; set; }
    }
}
