using Dem.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dem.Models.Entities
{
    public class BankDetail : Entity
    {

        public string BankName { get; set; }

        public string AccountNumber { get; set; }

        public string Bic { get; set; }

        public string Iban { get; set; }

        public DateTime CreatedAt { get; set; }


        public Employee Employee { get; set; }


        private BankDetail() { }

        public BankDetail(Guid id, string bankName, string accountNumber, string bic, string iban, DateTime createdAt)
        {
            Id = id;
            BankName = bankName;
            AccountNumber = accountNumber;
            Bic = bic;
            Iban = iban;
            CreatedAt = createdAt;
        }
    }
}
