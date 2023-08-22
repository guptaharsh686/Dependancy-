using SampleApi_Dependancy_Injection.Services.Interfaces;
using System;

namespace SampleApi_Dependancy_Injection.Services
{
    public class Operation : IOperationScoped,IOperationTransient,IOperationSingleton
    {
        public string OperationId { get; }


        public Operation()
        {
            OperationId = Guid.NewGuid().ToString();
        }
    }
}
