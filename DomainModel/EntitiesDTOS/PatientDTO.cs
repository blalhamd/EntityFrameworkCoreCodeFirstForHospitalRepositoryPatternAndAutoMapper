

using DomainModels.Enums;

namespace DomainModels.EntitiesDTOS
{
    public class PatientDTO
    {
        public string Name { get; set; }
        public DateTime? dateOfBirth { get; set; }
        public Gender gender { get; set; }
        public string? address { get; set; }
        public string phone { get; set; }
        public bool? HasInsurance { get; set; }
    }
}
