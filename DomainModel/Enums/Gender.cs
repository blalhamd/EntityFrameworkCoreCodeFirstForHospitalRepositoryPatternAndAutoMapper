
using System.Runtime.Serialization;

namespace DomainModels.Enums
{
    public enum Gender
    {

        [EnumMember(Value = "Male")]
        Male ,

        [EnumMember(Value = "Female")]
        Female
    }
}
