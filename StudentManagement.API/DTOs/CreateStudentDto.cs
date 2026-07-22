using System.ComponentModel.DataAnnotations;

namespace StudentManagement.API.DTOs
{
    public class CreateStudentDto
    {
        [Required]
        public string Name { get; set; } = "";

        [Required]
        [EmailAddress]
        public string Email { get; set; } = "";

        [Range(1, 100)]
        public int Age { get; set; }

        [Required]
        public string Course { get; set; } = "";
    }
}