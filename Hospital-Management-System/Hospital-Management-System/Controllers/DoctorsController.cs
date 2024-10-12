using AutoMapper;
using Hospital_Management_System.Models;
using Hospital_Management_System.Models.DTOs;
using Hospital_Management_System.Services.Iservice;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly IDoctor _doctorService;
        private readonly IMapper _mapper;
        private readonly ResponseDTO responseDTO;
        public DoctorsController(IDoctor doctorService, IMapper mapper)
        {
            _doctorService= doctorService;
            _mapper=mapper;
            responseDTO = new ResponseDTO();
        }

        [HttpPost]
        public async Task<ActionResult<ResponseDTO>> AddDoctor(DoctorDTO doctorDTO)
        {
            var doc = _mapper.Map<Doctor>(doctorDTO);
            var res = await _doctorService.AddDoctor(doc);
            responseDTO.Result = res;
            return Created($"{doc.Name}", responseDTO);
        }
        [HttpGet]
        public async Task<ActionResult<ResponseDTO>> GetAll()
        {
            var doctors = await _doctorService.Getall();
            responseDTO.Result = doctors;
            return Ok(responseDTO);
        }

        [HttpGet ("{Id}")]
        public async Task<ActionResult<ResponseDTO>>GetbyId(Guid Id)
        {
            var doctor = await _doctorService.GetdoctorbyId(Id);
            if(doctor == null)
            {
                return NotFound(responseDTO);
            }
            responseDTO.Result = doctor;
            return Ok(responseDTO);
        }
        [HttpDelete]
        public async Task<ActionResult<ResponseDTO>> DeleteDoctor(Guid Id)
        {
            var doctor = await _doctorService.GetdoctorbyId(Id);
            if (doctor==null)
            {
                return NotFound(responseDTO);
            }

            await _doctorService.DeleteDoctor(doctor);
            responseDTO.Errormessage = "Doctor deleted successfully";
            return (responseDTO);
        }
    }
    
    
}
