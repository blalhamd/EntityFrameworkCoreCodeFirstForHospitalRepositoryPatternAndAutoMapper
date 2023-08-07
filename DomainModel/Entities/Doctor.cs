
using DomainModels.Enums;

namespace DomainModels.Entities
{
    public class Doctor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Specialty specialty { get; set; }
        public string license { get; set; }
        public string contact { get; set; }
        public ICollection<Appointment> appointments { get; set; } = new List<Appointment>();
    }
}
