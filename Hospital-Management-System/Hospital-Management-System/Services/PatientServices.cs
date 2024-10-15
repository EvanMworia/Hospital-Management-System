using AutoMapper;
using Hospital_Management_System.Data;
using Hospital_Management_System.Exceptions;
using Hospital_Management_System.Models;
using Hospital_Management_System.Models.DTOs;
using Hospital_Management_System.Services.IServices;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Hospital_Management_System.Services
{
    public class PatientServices : IPatient
    {
        
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ResponseDTO _response;
        public PatientServices(ApplicationDbContext applicationDbContext, IMapper mapper)
        {

            _dbContext = applicationDbContext;
            _response = new ResponseDTO();
            _mapper = mapper;
        }
        public async Task<ResponseDTO> AddNewPatientRecord(PatientDTO patientDto)
        {
            try
            {
                var mappedPatient = _mapper.Map<Patient>(patientDto);
                await _dbContext.Patients.AddAsync(mappedPatient);
                await _dbContext.SaveChangesAsync();
                _response.Result = mappedPatient;
                _response.Message = $"Patient's {mappedPatient.Name} Record has been created";
                _response.IsSuccess = true;
                return _response;

            }
            catch (Exception ex)
            {

                _response.Message = ex.Message;
                _response.IsSuccess = false;
                return _response;
            }
        }

        public async Task<Patient> GetPatient(Guid id)
        {
            try
            {
                var patientResult = await _dbContext.Patients.FindAsync(id);

                if (patientResult == null)
                {
                    throw new NotFoundException($"No patient with {id} was found");
                }
                return patientResult;
            }
            catch (NotFoundException ex)
            {
                throw;
            }
            catch (Exception ex)
            {

                throw new Exception("An Error Occurred", ex);
            }
            
        }

        public async Task<Patient> UpdatePatientDetails(PatientDTO newDetails, Guid id) 
        {
            try
            {
                var foundPatient = await GetPatient(id);

                if (foundPatient != null)
                {

                    foundPatient.Name = newDetails.Name;
                    foundPatient.Gender = newDetails.Gender;
                    foundPatient.Phone = newDetails.Phone;
                    await _dbContext.SaveChangesAsync();
                    return foundPatient;
                }
                throw new NotFoundException("Patient not found");

            }
            catch (NotFoundException ex)
            {
                throw;

            }
            catch (Exception ex)
            {
                throw new Exception("", ex);
                //_response.Message = ex.Message;
                //_response.IsSuccess = false;
                //return _response;
            }
        }

        public Task<List<Appointment>> ViewPatientAppointments(Patient patientId)
        {
            throw new NotImplementedException();
        }
    }
}
