using AutoMapper;
using Entities;
using Shared.DataTransferObjects;
using Shared.DataTransferObjects.Booking;
using Shared.DataTransferObjects.BookingService;
using Shared.DataTransferObjects.Client;
using Shared.DataTransferObjects.Service;

namespace API;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Client, ClientDto>()
            .ForMember(dest => dest.ClientId, opt => opt.MapFrom(src => src.ClientId))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Contact, opt => opt.MapFrom(src => src.Contact))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password));

        CreateMap<Booking, BookingDto>()
            .ForMember(dest => dest.BookingId, opt => opt.MapFrom(src => src.BookingId))
            .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.StartDate))
            .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => src.EndDate))
            .ForMember(dest => dest.ClientId, opt => opt.MapFrom(src => src.ClientId))
            .ForMember(dest => dest.ClientName, opt => opt.MapFrom(src => src.Client.Name))
            .ForMember(dest => dest.Services, opt => opt.MapFrom(src =>
                src.BookingsServices.Select(bs => bs.Service)));


        CreateMap<Entities.Service, ServiceDto>()
            .ForMember(dest => dest.ServiceId, opt => opt.MapFrom(src => src.ServiceId))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));

        CreateMap<BookingService, BookingServiceDto>()
            .ForMember(dest => dest.BookingServiceId, opt => opt.MapFrom(src => src.BookingServiceId))
            .ForMember(dest => dest.BookingId, opt => opt.MapFrom(src => src.BookingId))
            .ForMember(dest => dest.ServiceId, opt => opt.MapFrom(src => src.ServiceId));

        CreateMap<BookingForCreationDto, Booking>();
        CreateMap<BookingServiceForCreationDto, BookingService>();
        CreateMap<BookingForUpdateDto, Booking>()
            .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.StartDate))
            .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => src.EndDate))
            .ForMember(dest => dest.ClientId, opt => opt.MapFrom(src => src.ClientId));
        CreateMap<UserForRegistrationDto, User>();


    }
}
