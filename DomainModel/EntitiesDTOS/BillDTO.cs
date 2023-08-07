

using DomainModels.Enums;

namespace DomainModels.EntitiesDTOS
{
    public class BillDTO
    {
        public decimal amount { get; set; }
        public DateTime dateTime { get; set; }
        public StatusBill status { get; set; }
        public int patientId { get; set; }
    }
}
