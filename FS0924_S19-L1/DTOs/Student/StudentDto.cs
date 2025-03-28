﻿using System.ComponentModel.DataAnnotations;

namespace FS0924_S19_L1.DTOs.Student
{
    public class StudentDto
    {
        [Required]
        public required Guid StudentId { get; set; }

        [Required]
        public required string Name { get; set; }

        [Required]
        public required string Surname { get; set; }

        [Required]
        public required string EmailAddress { get; set; }
    }
}
