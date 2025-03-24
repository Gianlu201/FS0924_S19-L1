using FS0924_S19_L1.Models;
using FS0924_S19_L1.Services;
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
        public async Task<IActionResult> GetAllStudent()
        {
            var studentsList = await _studentService.GetAllStudentsAsyc();

            if (studentsList == null)
            {
                return BadRequest(new { message = "Something went wrong!" });
            }

            if (studentsList.Count == 0)
            {
                return NoContent();
            }

            var count = studentsList.Count();

            var text = count == 1 ? $"{count} student found!" : $"{count} students found!";

            return Ok(new { message = text, students = studentsList });
        }

        [HttpPost]
        public async Task<IActionResult> CreateStudent([FromBody] Student student)
        {
            var result = await _studentService.CreateStudentAsync(student);

            if (!result)
            {
                return BadRequest(new { message = "Something went wrong!" });
            }

            return Ok(new { message = "Student created successfully!" });
        }
    }
}
