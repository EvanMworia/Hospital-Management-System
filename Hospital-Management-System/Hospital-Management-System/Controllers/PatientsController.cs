﻿using Hospital_Management_System.Exceptions;
using Hospital_Management_System.Models;
using Hospital_Management_System.Models.DTOs;
using Hospital_Management_System.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly IPatient _patient;
        private readonly ResponseDTO _response;

        public PatientsController(IPatient patient)
        {
            _patient = patient;
            _response = new ResponseDTO();
        }
        [HttpPost]
        public async Task<ActionResult<ResponseDTO>> AddNewPatient(PatientDTO patientDTO)
        {
            var result = await _patient.AddNewPatientRecord(patientDTO);
            if (result.IsSuccess == true)
            {
                return Created("", result);

            }
            return BadRequest();

        }
        [HttpGet]
        public async Task<ActionResult<Patient>> GetPatient(Guid id)
        {
            try
            {
                return await _patient.GetPatient(id);
            }
            catch (NotFoundException ex)
            {

                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
