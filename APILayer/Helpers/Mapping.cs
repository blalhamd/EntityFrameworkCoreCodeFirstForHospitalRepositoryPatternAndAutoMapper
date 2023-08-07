using AutoMapper;
using DomainModels.Entities;
using DomainModels.EntitiesDTOS;

namespace APILayer.Helpers
{
    public class Mapping : Profile
    {

        public Mapping() 
        {
            CreateMap<Bill, BillDTO>();
            CreateMap<Doctor, DoctorDTO>();
            CreateMap<Patient, PatientDTO>();
            CreateMap<Appointment, AppointmentDTO>();
            CreateMap<Prescription, PrescriptionDTO>();
            
            CreateMap<BillDTO, Bill>();
            CreateMap<DoctorDTO, Doctor>();
            CreateMap<PatientDTO, Patient>();
            CreateMap<AppointmentDTO, Appointment>();
            CreateMap<PrescriptionDTO, Prescription>();
        }
    }
}
