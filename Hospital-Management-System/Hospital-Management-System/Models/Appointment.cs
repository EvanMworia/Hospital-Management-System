namespace Hospital_Management_System.Models
{
    public class Appointment
    {
        public Guid Id { get; set; }
        public required DateTime AppointmentDate { get; set; }
        public required string DoctorName { get; set; }
        public required string PatientName { get; set; }

        //RELATIONSHPS
        public Patient? Patient { get; set; }
        public Doctor? Doctor { get; set; }
    }
}
