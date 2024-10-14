using AutoMapper;
using Hospital_Management_System.Models;
using Hospital_Management_System.Models.DTOs;

namespace Hospital_Management_System.Profiles
{
    public class PatientMappingProfile : Profile
    {
        public PatientMappingProfile()
        {
            CreateMap<PatientDTO, Patient>().ReverseMap();
        }
    }
}
