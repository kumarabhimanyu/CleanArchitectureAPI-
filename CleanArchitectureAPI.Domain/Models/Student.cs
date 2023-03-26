namespace CleanArchitectureAPI.Domain.Models
{
    public class Student : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Course { get; set; } = string.Empty;
        public int Age { get; set; }
    }
}
