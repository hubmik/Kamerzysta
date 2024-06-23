using Application;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CameraController : ControllerBase
    {
        private readonly IDeviceService _deviceService; 

        public CameraController(IDeviceService deviceService)
        {
            _deviceService = deviceService;
        }

        [HttpGet("getAllDevices")]
        [EnableCors("default")]
        public IActionResult Get()
        {
            return Ok(_deviceService.GetAllDevices());
        }
    }
}
