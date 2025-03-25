using FS0924_S19_L1.Data;
using FS0924_S19_L1.DTOs.Student;
using FS0924_S19_L1.Models;
using Microsoft.EntityFrameworkCore;

namespace FS0924_S19_L1.Services
{
    public class StudentService
    {
        private readonly ApplicationDbContext _context;

        public StudentService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> TrySaveAsync()
        {
            try
            {
                return await _context.SaveChangesAsync() > 0;
            }
            catch
            {
                return false;
            }
        }

        public async Task<List<StudentDto>?> GetAllStudentsAsyc()
        {
            try
            {
                var studentsList = await _context.Students.ToListAsync();

                var result = new List<StudentDto>();

                foreach (var student in studentsList)
                {
                    result.Add(
                        new StudentDto()
                        {
                            Name = student.Name,
                            Surname = student.Surname,
                            EmailAddress = student.EmailAddress,
                        }
                    );
                }

                return result;
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> CreateStudentAsync(Student student)
        {
            try
            {
                _context.Students.Add(student);

                return await TrySaveAsync();
            }
            catch
            {
                return false;
            }
        }

        public async Task<StudentDto?> GetStudentbyEmailAsync(string email)
        {
            try
            {
                var student = await _context.Students.FirstOrDefaultAsync(s =>
                    s.EmailAddress == email
                );

                if (student == null)
                {
                    return null;
                }

                var foundStudent = new StudentDto()
                {
                    Name = student.Name,
                    Surname = student.Surname,
                    EmailAddress = student.EmailAddress,
                };

                return foundStudent;
            }
            catch
            {
                return null;
            }
        }
    }
}
