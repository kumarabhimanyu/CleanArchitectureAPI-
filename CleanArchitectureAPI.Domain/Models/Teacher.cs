using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace CleanArchitectureAPI.Domain.Models
{
    public class Teacher : BaseEntity
    {
        [Column(TypeName = "Char(50)")]
        public string Name { get; set; } = string.Empty;
        public int Age { get; set; }

        [Column(TypeName = "Char(20)")]
        public string Qualification { get; set; } = string.Empty;
    }
}
