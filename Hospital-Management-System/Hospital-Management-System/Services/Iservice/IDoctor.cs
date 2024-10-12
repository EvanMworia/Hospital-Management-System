using Hospital_Management_System.Models;

namespace Hospital_Management_System.Services.Iservice
{
    public interface IDoctor
    {
        Task<List<Doctor>> Getall();
        Task<Doctor> GetdoctorbyId(Guid Id);
        Task<string> AddDoctor(Doctor doctor);
        Task<string> DeleteDoctor(Doctor doctor);

    }
}
