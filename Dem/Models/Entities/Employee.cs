using Dem.Models.Enums;
using Dem.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dem.Models.Entities
{
    public class Employee : Entity
    {
        public string FullName { get; set; } 
        public DateOnly DateOfBirth { get; set; }
        public bool HaveFamily { get; set; }
        public HealhStatus HealhStatus { get; set; }
        public string JobTitle { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }        
        public EmployeeStatus EmployeeStatus { get; set; }

        private Employee() { }

        public Employee(Guid id, string fullName, DateOnly dateOfBirth, bool haveFamily, HealhStatus healhStatus, string jobTitle, string email, string password, EmployeeStatus employeeStatus) : base(id)
        {
            FullName = fullName;
            DateOfBirth = dateOfBirth;
            HaveFamily = haveFamily;
            HealhStatus = healhStatus;
            JobTitle = jobTitle;
            Email = email;
            Password = password;
            EmployeeStatus = employeeStatus;
        }
    }
}
