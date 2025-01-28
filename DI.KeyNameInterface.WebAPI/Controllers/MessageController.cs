using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DI.KeyNameInterface.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IDataService _localService;
        private readonly IDataService _cloudService;

        public MessageController(
            [FromKeyedServices("local")] IDataService localService,
            [FromKeyedServices("cloud")] IDataService cloudService)
        {
            _localService = localService;
            _cloudService = cloudService;
        }

        [HttpGet]
        public string Get()
        {
            return $"Local: {_localService.GetMessage()}, Cloud: {_cloudService.GetMessage()}";
        }
    }
}
