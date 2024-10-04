namespace Hospital_Management_System.Models
{
    public class Patient
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Gender { get; set; }
        public required string Phone { get; set; }

        //RELATIONSHIPS
        public List<Appointment>? Appointments { get; set; }
        public List<Doctor>? Doctors { get; set; }
        public Ward? Ward { get; set; }
    }
}
