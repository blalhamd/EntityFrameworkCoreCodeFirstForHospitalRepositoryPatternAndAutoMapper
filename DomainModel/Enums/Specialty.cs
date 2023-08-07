﻿

using System.Runtime.Serialization;

namespace DomainModels.Enums
{
    public enum Specialty
    {
        [EnumMember(Value = "Cardiology")]
        Cardiology,

        [EnumMember(Value = "Dermatology")]
        Dermatology,

        [EnumMember(Value = "Neurology")]
        Neurology,

        [EnumMember(Value = "Pediatrics")]
        Pediatrics,

        [EnumMember(Value = "Ophthalmology")]
        Ophthalmology,

        [EnumMember(Value = "Psychiatry")]
        Psychiatry,

        [EnumMember(Value = "Radiology")]
        Radiology,

        [EnumMember(Value = "Dentistry")]
        Dentistry,

        [EnumMember(Value = "Orthopedics")]
        Orthopedics,

        [EnumMember(Value = "Gynecology")]
        Gynecology

    }
}
