using System.ServiceModel;

namespace EmployeeService
{
    [ServiceContract]
    public interface IEmployeeManager
    {
        [OperationContract]
        [FaultContract(typeof(EmployeeAlreadyExistsFault))]
        Employee CreateEmployee(int id, string name, string remarks);

        [OperationContract]
        [FaultContract(typeof(ResultNotFoundFault))]
        void AddRemark(int id, string remarks);

        [OperationContract]
        [FaultContract(typeof(ResultNotFoundFault))]
        void DeleteEmployeeById(int id);

        [OperationContract]
        void DeleteEmployees();
    }
}