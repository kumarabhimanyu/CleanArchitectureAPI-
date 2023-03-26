using System.ComponentModel.DataAnnotations;

namespace CleanArchitectureAPI.Service.Models
{
    public class TeacherServiceModel: BaseServiceModel
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;
        
        [Required]
        public int Age { get; set; }

        [Required]
        [MaxLength(20)]
        public string Qualification { get; set; } = string.Empty;
    }
}
