using Dem.Exceptions.InvalidExceptions;
using Dem.Exceptions.NotFoundExceptions;
using Dem.Models.Entities;
using Dem.Primitives;
using Dem.Services.DbServices.DbServiceInterfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileSystemGlobbing.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Dem.Services.DbServices
{
    public class PartnerService : GenericRepository<Partner>, IPartnerService
    {
        public PartnerService(ApplicationDbContext db) : base(db) { }

        public override void Add(Partner partner)
        {
            ValidatePartner(partner);
            base.Add(partner);
        }

        public override void Update(Partner partner)
        {
            ValidatePartner(partner);
            base.Update(partner);
        }
        public List<Partner> GetAllWithDetails()
        {
            return _db.Partners.Include(p => p.Requests).ToList();
        }

        public Partner Get(Guid id)
        {
            Partner? partner = GetById(id);

            return partner == null ? throw new PartnerNotFoundException(id) : partner;
        }
        public Partner GetWithDetails(Guid id)
        {
            Partner? partner = _db.Partners.Include(p => p.Requests).FirstOrDefault(p => p.Id == id);

            return partner == null ? throw new PartnerNotFoundException(id) : partner;
        }

        private void ValidatePartner(Partner partner)
        {
            string phonePattern = @"^\+?[1-9]\d{1,14}$";
            
            Regex phoneRegex = new Regex(phonePattern);

            bool p1 = String.IsNullOrEmpty(partner.Type);
            bool p2 = String.IsNullOrEmpty(partner.Name);
            bool p3 = String.IsNullOrEmpty(partner.Director);
            bool p4 = String.IsNullOrEmpty(partner.Email);
            bool p5 = String.IsNullOrEmpty(partner.Phone);
            bool p6 = String.IsNullOrEmpty(partner.LegalAddress);
            bool p7 = String.IsNullOrEmpty(partner.TIN);
            bool p8 = !MailAddress.TryCreate(partner.Email, out MailAddress? afsdsaaddress);
            bool p9 = phoneRegex.IsMatch(partner.Phone);




            if (partner == null)
            {
                throw new InvalidPartnerException();
            }
            if (
                String.IsNullOrEmpty(partner.Type)
                || String.IsNullOrEmpty(partner.Name)
                || String.IsNullOrEmpty(partner.Director)
                || String.IsNullOrEmpty(partner.Email)
                || String.IsNullOrEmpty(partner.Phone)
                || String.IsNullOrEmpty(partner.LegalAddress)
                || String.IsNullOrEmpty(partner.TIN)
                || !MailAddress.TryCreate(partner.Email, out MailAddress? address)
                || !phoneRegex.IsMatch(partner.Phone))
            {
                throw new InvalidPartnerException();
            }
        }
    }    
}
