using Microsoft.AspNetCore.Mvc;
using Service.Contracts;

namespace Project.Presentation.Controllers;

[Route("api/clients")]
[ApiController]
public class ClientsController : ControllerBase
{
    private readonly IServiceManager _service;
    public ClientsController(IServiceManager service) => _service = service;
    [HttpGet (Name = "GetClients")]
    public IActionResult GetClients()
    {
        var clients =
                _service.ClientService.GetAllClients(trackChanges: false); 
        return Ok(clients);
    }
    [HttpGet("{clientId:guid}", Name = "GetClientById")]
    public IActionResult GetClient(Guid clientId)
    {
        var client = _service.ClientService.GetClient(clientId, trackChanges: false);
        return Ok(client);
    }
}