using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JWT.Models.DTOS
{
    public class EmployeeDTO
    {
        public string NationalIdnumber { get; set; } = null!;
        public string? EmployeeName { get; set; }
        public string LoginId { get; set; } = null!;
        public string JobTitle { get; set; } = null!;
        public DateTime BirthDate { get; set; }
        public string MaritalStatus { get; set; } = null!;
        public string Gender { get; set; } = null!;
        public DateTime HireDate { get; set; }
        public short VacationHours { get; set; }
        public short SickLeaveHours { get; set; }
    }
}
