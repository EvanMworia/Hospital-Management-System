namespace Hospital_Management_System.Models
{
    public class Doctor
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Gender { get; set; }
        public required string Phone { get; set; }
        public required string Department { get; set; }

        //RELATIONSHIPS
        public List<Patient>? Patients { get; set; }
        public List<Appointment>? Appointments { get; set; }
        public List<Ward>? Wards { get; set; }
    }
}
