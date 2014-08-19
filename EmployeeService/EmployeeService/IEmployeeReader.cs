using System.Collections.Generic;
using System.ServiceModel;

namespace EmployeeService
{
    [ServiceContract]
    public interface IEmployeeReader
    {
        [OperationContract]
        [FaultContract(typeof(FaultException))]
        Employee GetEmployeeDetailsById(int id);

        [OperationContract(Name = "GetAllEmployees")]
        [FaultContract(typeof(ResultNotFoundFault))]
        List<Employee> GetEmployees();

        [OperationContract(Name = "GetEmployeesByName")]
        [FaultContract(typeof(ResultNotFoundFault))]
        List<Employee> GetEmployees(string name);
    }

}

