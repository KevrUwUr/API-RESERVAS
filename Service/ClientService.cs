using AutoMapper;
using Contracts;
using Entities;
using Entities.Exceptions.Client;
using Service.Contracts;
using Shared.DataTransferObjects.Client;

namespace Service
   
{
    internal sealed class ClientService : IClientService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public ClientService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper){
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }
        
        public IEnumerable<ClientDto> GetAllClients(bool trackChanges)
        {
                var clients =
                    _repository.Client.GetAllClients(trackChanges);
                var clientsDto =  _mapper.Map<IEnumerable<ClientDto>>(clients);
                return clientsDto;
        }
        
        public ClientDto GetClient(Guid clientId, bool trackChanges)
        {
            var client = _repository.Client.GetClient(clientId, trackChanges);
            Console.WriteLine("Client: " + client);
            if (client is null)
                throw new ClientNotFoundException(clientId);
            var clientDto = _mapper.Map<ClientDto>(client);
            return clientDto;
        }

    }
}