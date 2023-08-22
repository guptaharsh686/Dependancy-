using SampleApi_Dependancy_Injection.Controllers;
using SampleApi_Dependancy_Injection.Services.Interfaces;

namespace SampleApi_Dependancy_Injection.Services
{
    public class FirstService
    {
        private readonly ILogger<FirstService> _logger;
        private readonly IOperationTransient operationTransient;
        private readonly IOperationScoped operationScoped;
        private readonly IOperationSingleton operationSingleton;

        public FirstService(ILogger<FirstService> logger, IOperationScoped operationScoped, IOperationSingleton operationSingleton, IOperationTransient operationTransient)
        {
            _logger = logger;
            this.operationTransient = operationTransient;
            this.operationScoped = operationScoped;
            this.operationSingleton = operationSingleton;
        }

        public void generateResult()
        {
            _logger.LogInformation($"First Service :  Transient : {operationTransient.OperationId}");
            _logger.LogInformation($"First Service : Scoped : {operationScoped.OperationId}");
            _logger.LogInformation($"First Service : Singleton : {operationSingleton.OperationId}");
        }
    }
}
