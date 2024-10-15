using AutoMapper;
using Hospital_Management_System.Data;
using Hospital_Management_System.Models;
using Hospital_Management_System.Services.Iservice;
using Microsoft.EntityFrameworkCore;

namespace Hospital_Management_System.Services
{
    public class DoctorService : IDoctor
    {
        public readonly ApplicationDbContext _context;
        
        public DoctorService(ApplicationDbContext context)
        {
            _context = context;
           
        }

        public  async Task<string> AddDoctor(Doctor doctor)
        {
            _context.Doctors.Add(doctor);
            await _context.SaveChangesAsync();
            return "Doctor added successfully";
        }

        public async Task<string> DeleteDoctor(Doctor doctor)
        {
            _context.Doctors.Remove(doctor);
            await _context.SaveChangesAsync();
            return "Doctor deleted successsfully";
        }

        public async Task<List<Doctor>> Getall()
        {
            return await _context.Doctors.ToListAsync();
        }

        public async Task<Doctor> GetdoctorbyId(Guid Id)
        {
            return await _context.Doctors.Where(x => x.Id == Id).FirstOrDefaultAsync();
        }
    }
}
