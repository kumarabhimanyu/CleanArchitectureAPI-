using System.ComponentModel.DataAnnotations;

namespace CleanArchitectureAPI.Service.Models
{
    public class StudentServiceModel: BaseServiceModel
    {

        [Required]
        [MaxLength(50)]
        public string FullName { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string Address { get; set; } = string.Empty;

        [Required]
        [MaxLength(20)]
        public string Course { get; set; } = string.Empty;

        [Required]
        public DateTime DoB { get; set; }
    }
}
