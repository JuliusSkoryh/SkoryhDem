using Dem.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dem.Models
{
    public class PassportInfo : Entity
    {

        public string PassportNumber { get; set; }

        public string IssuedBy { get; set; }

        public DateOnly IssueDate { get; set; }

        public DateOnly ExpirationDate { get; set; }

       
        public Employee Employee { get; set; }

        private PassportInfo() { }

        public PassportInfo(Guid id, string passportNumber, string issuedBy, DateOnly issueDate, DateOnly expirationDate)
        {
            Id = id;
            PassportNumber = passportNumber;
            IssuedBy = issuedBy;
            IssueDate = issueDate;
            ExpirationDate = expirationDate;
        }
    }
}
