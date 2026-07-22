using StudentManagement.API.DTOs;

namespace StudentManagement.API.Services.Interfaces
{
    public interface IStudentService
    {
        Task<IEnumerable<StudentDto>> GetAllAsync();

        Task<StudentDto?> GetByIdAsync(int id);

        Task<StudentDto> AddAsync(CreateStudentDto dto);

        Task<bool> UpdateAsync(int id, UpdateStudentDto dto);

        Task<bool> DeleteAsync(int id);
    }
}