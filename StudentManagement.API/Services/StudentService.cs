using Microsoft.Extensions.Logging;
using StudentManagement.API.DTOs;
using StudentManagement.API.Models;
using StudentManagement.API.Repositories.Interfaces;
using StudentManagement.API.Services.Interfaces;

namespace StudentManagement.API.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _repository;
        private readonly ILogger<StudentService> _logger;

        public StudentService(
            IStudentRepository repository,
            ILogger<StudentService> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<IEnumerable<StudentDto>> GetAllAsync()
        {
            _logger.LogInformation("Fetching all students.");

            var students = await _repository.GetAllAsync();

            return students.Select(s => new StudentDto
            {
                Id = s.Id,
                Name = s.Name,
                Email = s.Email,
                Age = s.Age,
                Course = s.Course,
                CreatedDate = s.CreatedDate
            });
        }

        public async Task<StudentDto?> GetByIdAsync(int id)
        {
            _logger.LogInformation("Fetching student with Id {StudentId}", id);

            var student = await _repository.GetByIdAsync(id);

            if (student == null)
            {
                _logger.LogWarning("Student with Id {StudentId} not found.", id);
                return null;
            }

            return new StudentDto
            {
                Id = student.Id,
                Name = student.Name,
                Email = student.Email,
                Age = student.Age,
                Course = student.Course,
                CreatedDate = student.CreatedDate
            };
        }

        public async Task<StudentDto> AddAsync(CreateStudentDto dto)
        {
            _logger.LogInformation("Adding new student with Email {Email}", dto.Email);

            var student = new Student
            {
                Name = dto.Name,
                Email = dto.Email,
                Age = dto.Age,
                Course = dto.Course,
                CreatedDate = DateTime.UtcNow
            };

            await _repository.AddAsync(student);

            _logger.LogInformation("Student added successfully with Id {StudentId}", student.Id);

            return new StudentDto
            {
                Id = student.Id,
                Name = student.Name,
                Email = student.Email,
                Age = student.Age,
                Course = student.Course,
                CreatedDate = student.CreatedDate
            };
        }

        public async Task<bool> UpdateAsync(int id, UpdateStudentDto dto)
        {
            _logger.LogInformation("Updating student with Id {StudentId}", id);

            var student = await _repository.GetByIdAsync(id);

            if (student == null)
            {
                _logger.LogWarning("Student with Id {StudentId} not found.", id);
                return false;
            }

            student.Name = dto.Name;
            student.Email = dto.Email;
            student.Age = dto.Age;
            student.Course = dto.Course;

            await _repository.UpdateAsync(student);

            _logger.LogInformation("Student with Id {StudentId} updated successfully.", id);

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            _logger.LogInformation("Deleting student with Id {StudentId}", id);

            var student = await _repository.GetByIdAsync(id);

            if (student == null)
            {
                _logger.LogWarning("Student with Id {StudentId} not found.", id);
                return false;
            }

            await _repository.DeleteAsync(student);

            _logger.LogInformation("Student with Id {StudentId} deleted successfully.", id);

            return true;
        }
    }
}