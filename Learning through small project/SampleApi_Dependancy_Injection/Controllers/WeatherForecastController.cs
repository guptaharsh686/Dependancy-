using Microsoft.AspNetCore.Mvc;
using SampleApi_Dependancy_Injection.Services;
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

        //creating dependancy of first dervice in whether controller
        private readonly FirstService firstService;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IOperationScoped operationScoped, IOperationSingleton operationSingleton,IOperationTransient operationTransient, FirstService firstService)
        {
            _logger = logger;
            this.operationTransient = operationTransient;
            this.operationScoped = operationScoped;
            this.operationSingleton = operationSingleton;
            this.firstService = firstService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            _logger.LogInformation("Hello From Logger");
            _logger.LogInformation($"Transient : {operationTransient.OperationId}");
            _logger.LogInformation($"Scoped : {operationScoped.OperationId}");
            _logger.LogInformation($"Singleton : {operationSingleton.OperationId}");
            firstService.generateResult();
            return Ok();
        }

        //Scoped will be different for different endpoint
        //transient will be different for each call
        //singleton will be same for application lifetime
        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAll()
        {
            _logger.LogInformation("Hello From Logger");
            _logger.LogInformation($"Transient : {operationTransient.OperationId}");
            _logger.LogInformation($"Scoped : {operationScoped.OperationId}");
            _logger.LogInformation($"Singleton : {operationSingleton.OperationId}");
            firstService.generateResult();
            return Ok();
        }

    }
}