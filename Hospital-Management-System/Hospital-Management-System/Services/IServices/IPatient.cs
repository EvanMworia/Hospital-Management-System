using Hospital_Management_System.Models;
using Hospital_Management_System.Models.DTOs;

namespace Hospital_Management_System.Services.IServices
{
    public interface IPatient
    {
        Task<ResponseDTO> AddNewPatientRecord(PatientDTO patientDto);
        Task<Patient> GetPatient(Guid id);
        Task<List<Appointment>> ViewPatientAppointments(Patient patientId);
        Task<Patient> UpdatePatientDetails(PatientDTO newDetails, Guid id);

    }
}
