using Microsoft.AspNetCore.Mvc;
using StudentManagement.API.DTOs;
using StudentManagement.API.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace StudentManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStudents()
        {
            var students = await _studentService.GetAllAsync();

            return Ok(students);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudent(int id)
        {
            var student = await _studentService.GetByIdAsync(id);

            if (student == null)
                return NotFound(new
                {
                    message = "Student not found"
                });

            return Ok(student);
        }

        [HttpPost]
        public async Task<IActionResult> AddStudent(CreateStudentDto dto)
        {
            var student = await _studentService.AddAsync(dto);

            return CreatedAtAction(
                nameof(GetStudent),
                new { id = student.Id },
                student);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(
    int id,
    UpdateStudentDto dto)
        {
            var updated = await _studentService.UpdateAsync(id, dto);

            if (!updated)
                return NotFound(new
                {
                    message = "Student not found"
                });

            return Ok(new
            {
                message = "Student updated successfully"
            });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var deleted = await _studentService.DeleteAsync(id);

            if (!deleted)
                return NotFound(new
                {
                    message = "Student not found"
                });

            return Ok(new
            {
                message = "Student deleted successfully"
            });
        }

    }
}