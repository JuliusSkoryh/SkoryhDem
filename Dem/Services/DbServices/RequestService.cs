using Dem.Exceptions.InvalidExceptions;
using Dem.Exceptions.NotFoundExceptions;
using Dem.Models.Entities;
using Dem.Primitives;
using Dem.Services.DbServices.DbServiceInterfaces;
using Microsoft.EntityFrameworkCore;

namespace Dem.Services.DbServices
{
    public class RequestService : GenericRepository<Request>, IRequestService
    {
        public RequestService(ApplicationDbContext db) : base(db) { }

        public override void AddAsync(Request request)
        {
            ValidateRequest(request);
            base.AddAsync(request);
        }

        public override void UpdateAsync(Request entity)
        {
            ValidateRequest(entity);
            base.UpdateAsync(entity);
        }

        public ICollection<Request> GetAllWithDetailsAsync()
        {
            return _db.Requests.Include(p => p.Partner).Include(p => p.Product).ToList();
        }

        public Request GetAsync(Guid id)
        {
            Request? request = GetByIdAsync(id);

            return request == null ? throw new RequestNotFoundException(id) : request;
        }
        public Request GetWithDetailsAsync(Guid id)
        {
            Request? request = _db.Requests.Include(p => p.Partner).Include(p => p.Product).FirstOrDefault(p => p.Id == id);

            return request == null ? throw new RequestNotFoundException(id) : request;
        }

        private void ValidateRequest(Request request)
        {
            if (request == null)
            {
                throw new InvalidRequestException();
            }
            if (request.DateOfCreation > request.DateOfClosing)
            {
                throw new InvalidProductException("Заказ не может быть закрыт раньше, чем был создан.");
            }
            if (request.Price < 0)
            {
                throw new InvalidProductException("цена не может быть ниже нуля.");
            }
            if (request.QuantityOfProduct < 0)
            {
                throw new InvalidProductException("количество продукции в заказе не может быть меньше нуля.");
            }
        }
    }
}
