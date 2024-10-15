namespace Hospital_Management_System.Models.DTOs
{
    public class ResponseDTO
    {
        public string Errormessage { get; set; } = string.Empty;
        public string? Message { get; set; }

        public object Result { get; set; } = default!;

        public bool IsSuccess { get; set; } = true;
    }
}
