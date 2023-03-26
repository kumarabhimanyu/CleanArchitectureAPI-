namespace CleanArchitectureAPI.Service.Models
{
    public class StudentServiceModel
    {
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Course { get; set; } = string.Empty;
        public DateTime DoB { get; set; }
    }
}
