using System.ComponentModel.DataAnnotations;

namespace FS0924_S19_L1.DTOs.Student
{
    public class GetStudentsResponseDto
    {
        [Required]
        public required string Message { get; set; }

        [Required]
        public required List<StudentDto>? Students { get; set; }
    }
}
