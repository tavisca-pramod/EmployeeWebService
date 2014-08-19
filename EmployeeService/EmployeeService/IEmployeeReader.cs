using System.Collections.Generic;
using System.ServiceModel;

namespace EmployeeService
{
    [ServiceContract]
    public interface IEmployeeReader
    {
        [OperationContract]
        [FaultContract(typeof(ResultNotFoundFault))]
        [FaultContract(typeof(InvalidIdValueFault))]
        Employee GetEmployeeDetailsById(int id);

        [OperationContract(Name = "GetAllEmployees")]
        [FaultContract(typeof(ResultNotFoundFault))]
        List<Employee> GetEmployees();

        [OperationContract(Name = "GetEmployeesByName")]
        [FaultContract(typeof(ResultNotFoundFault))]
        [FaultContract(typeof(InvalidNameSizeFault))]
        [FaultContract(typeof(InvalidNameValueFault))]        
        List<Employee> GetEmployees(string name);

        [OperationContract]
        [FaultContract(typeof(ResultNotFoundFault))]
        List<Employee> GetEmployeesWithRemark();
    }

}

