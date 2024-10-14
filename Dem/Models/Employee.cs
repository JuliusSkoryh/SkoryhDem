using Dem.Models.Enums;
using Dem.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dem.Models
{
    public class Employee : Entity
    {
        public string FullName { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public bool HaveFamily { get; set; }
        public HealhStatus HealhStatus { get; set; }
        public string JobTitle { get; set; }

        public Guid PassportInfoId { get; set; }
        public PassportInfo PassportInfo { get; set; }

        public ICollection<BankDetail> BankDetails { get; set; }

        private Employee() { }

        public Employee(Guid id, string fullName, DateOnly dateOfBirth, bool haveFamily, HealhStatus healhStatus, string jobTitle, Guid passportInfoId)
        {
            Id = id;
            FullName = fullName;
            DateOfBirth = dateOfBirth;
            HaveFamily = haveFamily;
            HealhStatus = healhStatus;
            JobTitle = jobTitle;
            PassportInfoId = passportInfoId;
        }
    }
}
