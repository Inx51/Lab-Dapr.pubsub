using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Sub.Controllers;

[ApiController]
[Route("[controller]")]
public class ProcessController : ControllerBase
{
    private readonly ILogger<ProcessController> _logger;

    public ProcessController(ILogger<ProcessController> logger)
    {
        _logger = logger;
    }

    [HttpPost("/Process")]
    public void Run([FromBody] object body)
    {
         _logger.LogInformation(body.ToString());
    }
}
