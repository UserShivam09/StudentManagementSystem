using StudentManagement.API.Models;

namespace StudentManagement.API.Repositories.Interfaces
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetAllAsync();

        Task<Student?> GetByIdAsync(int id);

        Task<Student> AddAsync(Student student);

        Task UpdateAsync(Student student);

        Task DeleteAsync(Student student);
    }
}