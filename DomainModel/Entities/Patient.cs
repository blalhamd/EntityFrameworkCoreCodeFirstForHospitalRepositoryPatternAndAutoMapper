

using DomainModels.Enums;
using System.Reflection;

namespace DomainModels.Entities
{
    public class Patient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? dateOfBirth { get; set; }
        public Gender gender { get; set; }
        public string? address { get; set; }
        public string phone { get; set; }
        public bool? HasInsurance { get; set; }
        public ICollection<Bill> Bills { get; set; } = new List<Bill>();
        public ICollection<Appointment> appointments { get; set; } = new List<Appointment>();
    }
}
