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
                _response.Result = patientDto;
                _response.Message = $"Patient's {patientDto.Name} Record has been created";
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

        public async Task<ResponseDTO> UpdatePatientDetails(PatientDTO newDetails, Guid id) 
        {
            try
            {
                var patientRecord = _dbContext.Patients.Find(id);
                if (patientRecord != null)
                {
                    patientRecord.Name = newDetails.Name;
                    patientRecord.Gender = newDetails.Gender;
                    patientRecord.Phone = newDetails.Phone;

                    await _dbContext.SaveChangesAsync();

                    _response.Message = $"{patientRecord.Name}'s Details have been updated";
                    _response.IsSuccess = true;
                    _response.Result = patientRecord;
                    return _response;
                }
                _response.Message = "Something went wrong ";
                _response.IsSuccess = false;
                return _response;

            }
            catch (Exception ex)
            {

                _response.Message = ex.Message;
                _response.IsSuccess = false;
                return _response;
            }
        }

        public Task<List<Appointment>> ViewPatientAppointments(Patient patientId)
        {
            throw new NotImplementedException();
        }
    }
}
