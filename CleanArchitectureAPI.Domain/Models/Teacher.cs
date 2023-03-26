using static CleanArchitectureAPI.Domain.Enums.Enums;

namespace CleanArchitectureAPI.Domain.Models
{
    public class Teacher : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public int Age { get; set; }
        public string Qualification { get; set; } = string.Empty;
        public bool IsGraduate
        {
            get
            {
                return Qualification == QualificationStatus.Graduate.ToString();
            }
        }

    }
}
