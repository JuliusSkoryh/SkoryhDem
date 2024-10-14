using Dem.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dem.Models
{
    public class Partner :Entity
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public string Director { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string LegalAddress { get; set; }
        public string TIN { get; set; }
        public byte[]? Logo { get; set; }
        public int Rating { get; set; }

        public ICollection<ProductHistory> ProductHistories { get; set; }
        public ICollection<Request> Requests { get; set; }

        private Partner () { }

        public Partner (Guid id, string type, string name, string director, string email, string phone, string legalAddress, string tIN, int rating, byte[] logo)
        {
            Id = id;
            Type = type;
            Name = name;
            Director = director;
            Email = email;
            Phone = phone;
            LegalAddress = legalAddress;
            TIN = tIN;
            Rating = rating;
            Logo = logo;
        }
    }
}
