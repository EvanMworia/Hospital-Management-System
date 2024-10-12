using AutoMapper;
using Hospital_Management_System.Models;
using Hospital_Management_System.Models.DTOs;

namespace Hospital_Management_System.Profiles
{
    public class DoctorProfile:Profile
    {
        public DoctorProfile() {
            CreateMap<DoctorDTO, Doctor>().ReverseMap();
        }

    }
}
