using System.ComponentModel.DataAnnotations;

namespace FS0924_S19_L1.DTOs.Student
{
    public class EditStudentResponseDto
    {
        [Required]
        public required string Message { get; set; }
    }
}
