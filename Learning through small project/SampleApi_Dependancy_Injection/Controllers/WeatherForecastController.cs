using Microsoft.AspNetCore.Mvc;
using SampleApi_Dependancy_Injection.Services.Interfaces;

namespace SampleApi_Dependancy_Injection.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IOperationTransient operationTransient;
        private readonly IOperationScoped operationScoped;
        private readonly IOperationSingleton operationSingleton;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IOperationScoped operationScoped, IOperationSingleton operationSingleton,IOperationTransient operationTransient)
        {
            _logger = logger;
            this.operationTransient = operationTransient;
            this.operationScoped = operationScoped;
            this.operationSingleton = operationSingleton;
        }

        [HttpGet]
        public IActionResult Get()
        {
            _logger.LogInformation("Hello From Logger");
            _logger.LogInformation($"Transient : {operationTransient.OperationId}");
            _logger.LogInformation($"Scoped : {operationScoped.OperationId}");
            _logger.LogInformation($"Singleton : {operationSingleton.OperationId}");

            return Ok();
        }
    }
}