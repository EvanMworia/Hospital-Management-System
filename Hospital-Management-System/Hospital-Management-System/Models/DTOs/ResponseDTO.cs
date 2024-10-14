namespace Hospital_Management_System.Models.DTOs
{
    public class ResponseDTO
    {
        public string? Message { get; set; }

        public object? Result { get; set; }

        public bool IsSuccess { get; set; } = false;
    }
}
