using System;
using System.Collections.Generic;
using System.Linq;
using Contracts;
using Entities;

namespace Repository
{
    public class BookingServiceRepository : RepositoryBase<BookingService>, IBookingServiceRepository
    {
        public BookingServiceRepository(RepositoryContext repositoryContext) 
            : base(repositoryContext)
        {
        }

        public void CreateBookingService(BookingService bookingService) => Create(bookingService);
        public void DeleteBookingServicesByBookingId(Guid bookingId)
        {
            var bookingServices = FindByCondition(bs => bs.BookingId.Equals(bookingId), trackChanges: false).ToList();
            foreach (var bookingService in bookingServices)
            {
                Delete(bookingService);
            }
        }
    }
}