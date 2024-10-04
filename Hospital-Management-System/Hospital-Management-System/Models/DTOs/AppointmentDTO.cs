namespace Hospital_Management_System.Models.DTOs
{
    public class AppointmentDTO
    {
        public required DateTime AppointmentDate { get; set; }
        public required string DoctorName { get; set; }
        public required string PatientName { get; set; }
    }
}
