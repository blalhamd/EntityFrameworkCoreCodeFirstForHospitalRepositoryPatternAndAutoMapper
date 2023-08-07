

using DomainModels.Enums;

namespace DomainModels.Entities
{
    public class Bill
    {
        public int Id { get; set; }
        public decimal amount { get; set; }
        public DateTime dateTime { get; set; }
        public StatusBill status { get; set; }
        public int patientId { get; set; }
        public Patient patient { get; set; }

    }
}
