using System.ComponentModel.DataAnnotations;

namespace FS0924_S19_L1.DTOs.Student
{
    public class GetStudentResponseDto
    {
        [Required]
        public required string Message { get; set; }

        [Required]
        public StudentDto? Student { get; set; }
    }
}
