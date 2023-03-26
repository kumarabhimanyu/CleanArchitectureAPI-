using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace CleanArchitectureAPI.Domain.Models
{
    public class Student : BaseEntity
    {
        [Column(TypeName = "Char(50)")]
        public string FullName { get; set; } = string.Empty;

        [Column(TypeName = "Char(50)")]
        public string FirstName { get; set; } = string.Empty;
        
        [Column(TypeName = "Char(50)")]
        public string LastName { get; set; } = string.Empty;
        
        [Column(TypeName = "Char(100)")]
        public string Address { get; set; } = string.Empty;
        
        [Column(TypeName = "Char(20)")]
        public string Course { get; set; } = string.Empty;
        public DateTime DoB { get; set; }
        public int Age { get; set; }
    }
}
