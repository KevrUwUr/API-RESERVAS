using AutoMapper;
using Contracts;
using Service.Contracts;

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
    }
}