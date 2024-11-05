using System.Linq;
using Contracts;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class BookingRepository : RepositoryBase<Booking>, IBookingRepository
    {
        public BookingRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public IEnumerable<Booking> GetAllBookingsFiltered(Guid? clientId, Guid? serviceId, DateTime? sDate, DateTime? eDate, bool trackChanges)
{
    IQueryable<Booking> query;

    if (clientId.HasValue || serviceId.HasValue || sDate.HasValue || eDate.HasValue)
    {
        query = FindByCondition(c => 
                    (!clientId.HasValue || c.ClientId.Equals(clientId.Value)) &&
                    (!serviceId.HasValue || c.BookingsServices.Any(bs => bs.ServiceId.Equals(serviceId.Value))) &&
                    (!sDate.HasValue || c.StartDate >= sDate.Value) &&
                    (!eDate.HasValue || c.EndDate <= eDate.Value),
                trackChanges)
            .Include(b => b.Client) 
            .Include(b => b.BookingsServices) 
            .ThenInclude(bs => bs.Service) 
            .OrderBy(c => c.ClientId);
    }
    else
    {
        query = FindAll(trackChanges)
            .Include(b => b.Client) 
            .Include(b => b.BookingsServices) 
            .ThenInclude(bs => bs.Service) 
            .OrderBy(c => c.ClientId);
    }

    return query.ToList();
}

        
        public void CreateBooking (Booking booking) => Create(booking);

        public Booking GetById(Guid bookingId, bool trackChanges)
{
    return FindByCondition(b => b.BookingId.Equals(bookingId), trackChanges)
        .Include(b => b.Client) 
        .Include(b => b.BookingsServices) 
        .ThenInclude(bs => bs.Service) 
        .SingleOrDefault(); 
}

        public void DeleteBooking(Booking booking) => Delete(booking);
        public void UpdateBooking(Booking booking) => Update(booking);
    }
}