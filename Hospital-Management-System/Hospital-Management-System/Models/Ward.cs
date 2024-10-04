namespace Hospital_Management_System.Models
{
    public class Ward
    {
        public Guid Id { get; set; }
        public required string RoomNumber { get; set; }
        public int BedCount { get; set; } = 5;
        public bool BedAvailable { get; set; } = true;

        //RELATIONSHIPS
        public List<Patient>? Patients { get; set; }
        public List<Doctor>? Doctors { get; set; }
    }
}
