using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JWT.Models.ViewModels
{
    public class EmployeeVM
    {
        public string? EmployeeName { get; set; }
        public string LoginId { get; set; } = null!;
        public string JobTitle { get; set; } = null!;
        public DateTime BirthDate { get; set; }
    }
}
