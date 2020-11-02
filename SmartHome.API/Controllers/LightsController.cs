using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SmartHome.API.Repositories;
using System.Threading.Tasks;

namespace SmartHome.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LightsController : Controller
    {
        private readonly ILogger<LightsController> _logger;
        private readonly LightRepository _lightRepository;

        public LightsController(
            ILogger<LightsController> logger,
            LightRepository lightRepository)
        {
            _logger = logger;
            _lightRepository = lightRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _lightRepository.GetAllAsync());
        }
    }
}
