using AutoMapper;
using Contracts;
using Entities.Exceptions.Client;
using Entities.Exceptions.Service;
using Service.Contracts;
using Shared.DataTransferObjects.Client;
using Shared.DataTransferObjects.Service;

namespace Service
   
{
    internal sealed class ServiceService : IServiceService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public ServiceService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper){
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }
        
        public IEnumerable<ServiceDto> GetAllServices(bool trackChanges)
        {
            var service =
                _repository.Service.GetAllServices(trackChanges);
            var serviceDto =  _mapper.Map<IEnumerable<ServiceDto>>(service);
            return serviceDto;
        }
        
        public ServiceDto GetService(Guid serviceId, bool trackChanges)
        {
            var service = _repository.Service.GetService(serviceId, trackChanges);
            if (service is null)
                throw new ServiceNotFoundException(serviceId);
            var serviceDto = _mapper.Map<ServiceDto>(service);
            return serviceDto;
        }
    }
}