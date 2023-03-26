using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureAPI.Service.Models
{
    public class TeacherServiceModel
    {
        public string Name { get; set; } = string.Empty;
        public int Age { get; set; }
        public string Qualification { get; set; } = string.Empty;
    }
}
