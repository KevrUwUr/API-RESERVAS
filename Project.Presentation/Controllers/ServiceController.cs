using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;

namespace Project.Presentation.Controllers;

[Route("api/services")]
[ApiController]
public class ServiceController : ControllerBase
{
    private readonly IServiceManager _service;
    public ServiceController(IServiceManager service) => _service = service;
    [HttpGet (Name = "GetServices")]
    // [Authorize]
    public IActionResult GetServices()
    {
        var services =
            _service.ServiceService.GetAllServices(trackChanges: false); 
        return Ok(services);
    }
}