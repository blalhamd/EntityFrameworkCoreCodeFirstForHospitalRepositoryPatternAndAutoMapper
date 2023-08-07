

using System.Runtime.Serialization;

namespace DomainModels.Enums
{
    public enum StatusAppointment
    {

        [EnumMember(Value = "pending")]
        pending,

        [EnumMember(Value = "Confirmed")]
        Confirmed,

        [EnumMember(Value = "cancelled")]
        cancelled

    }
}
