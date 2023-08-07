

using System.Runtime.Serialization;

namespace DomainModels.Enums
{
    public enum StatusBill
    {
        [EnumMember(Value = "Paid")]
        Paid,

        [EnumMember(Value = "Unpaid")]
        Unpaid,

        [EnumMember(Value = "overdue")]
        overdue,

    }
}
