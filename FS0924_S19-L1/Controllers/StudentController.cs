﻿using FS0924_S19_L1.DTOs.Student;
using FS0924_S19_L1.Models;
using FS0924_S19_L1.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FS0924_S19_L1.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly StudentService _studentService;

        public StudentController(StudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllStudent()
        {
            var studentsList = await _studentService.GetAllStudentsAsyc();

            if (studentsList == null)
            {
                return BadRequest(
                    new GetStudentsResponseDto()
                    {
                        Message = "Something went wrong!",
                        Students = null,
                    }
                );
            }

            if (studentsList.Count == 0)
            {
                return NoContent();
            }

            var count = studentsList.Count();

            var text = count == 1 ? $"{count} student found!" : $"{count} students found!";

            return Ok(new GetStudentsResponseDto() { Message = text, Students = studentsList });
        }

        [HttpPost]
        public async Task<IActionResult> CreateStudent(
            [FromBody] CreateStudentRequestDto createStudent
        )
        {
            var student = new Student()
            {
                Name = createStudent.Name,
                Surname = createStudent.Surname,
                EmailAddress = createStudent.EmailAddress,
            };

            var result = await _studentService.CreateStudentAsync(student);

            if (!result)
            {
                return BadRequest(
                    new CreateStudentResponseDto() { Message = "Something went wrong!" }
                );
            }

            return Ok(new CreateStudentResponseDto() { Message = "Student created successfully!" });
        }

        [HttpGet("{email}")]
        public async Task<IActionResult> GetStudentByEmail(string email)
        {
            var result = await _studentService.GetStudentbyEmailAsync(email);

            if (result == null)
            {
                return BadRequest(
                    new GetStudentResponseDto() { Message = "Something went wrong!" }
                );
            }

            return Ok(new GetStudentResponseDto() { Message = "Student found!", Student = result });
        }

        [HttpPut]
        public async Task<IActionResult> EditStudent(
            [FromQuery] Guid id,
            [FromBody] EditStudentRequestDto editStudent
        )
        {
            var result = await _studentService.EditStudentAsync(id, editStudent);

            return result
                ? Ok(new EditStudentResponseDto() { Message = "Student updated successfully!" })
                : BadRequest(new EditStudentResponseDto() { Message = "Something went wrong!" });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] Guid id)
        {
            var result = await _studentService.DeleteStudentByIdAsync(id);

            return result
                ? Ok(new DeleteStudentResponseDto() { Message = "Student deleted successfully!" })
                : BadRequest(new DeleteStudentResponseDto() { Message = "Something went wrong!" });
        }
    }
}
