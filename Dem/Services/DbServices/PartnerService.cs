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

        public override void AddAsync(Partner partner)
        {
            ValidatePartner(partner);
            base.AddAsync(partner);
        }

        public override void UpdateAsync(Partner partner)
        {
            ValidatePartner(partner);
            base.UpdateAsync(partner);
        }
        public ICollection<Partner> GetAllWithDetailsAsync()
        {
            return _db.Partners.Include(p => p.Requests).ToList();
        }

        public Partner GetAsync(Guid id)
        {
            Partner? partner = GetByIdAsync(id);

            return partner == null ? throw new PartnerNotFoundException(id) : partner;
        }
        public Partner GetWithDetailsAsync(Guid id)
        {
            Partner? partner = _db.Partners.Include(p => p.Requests).FirstOrDefault(p => p.Id == id);

            return partner == null ? throw new PartnerNotFoundException(id) : partner;
        }

        private void ValidatePartner(Partner partner)
        {
            string phonePattern = @"^\+?[1-9]\d{1,14}$";
            Regex phoneRegex = new Regex(phonePattern);

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
                || phoneRegex.IsMatch(partner.Phone))
            {
                throw new InvalidPartnerException();
            }
        }
    }    
}
