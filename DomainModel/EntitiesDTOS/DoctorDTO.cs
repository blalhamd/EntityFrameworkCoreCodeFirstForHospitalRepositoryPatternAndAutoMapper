

using DomainModels.Enums;

namespace DomainModels.EntitiesDTOS
{
    public class DoctorDTO
    {
        public string Name { get; set; }
        public Specialty specialty { get; set; }
        public string license { get; set; }
        public string contact { get; set; }
    }
}
