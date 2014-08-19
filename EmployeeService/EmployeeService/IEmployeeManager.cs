using System.ServiceModel;

namespace EmployeeService
{
    [ServiceContract]
    public interface IEmployeeManager
    {
        [OperationContract]
        [FaultContract(typeof(EmployeeAlreadyExistsFault))]
        [FaultContract(typeof(InvalidNameValue))]
        [FaultContract(typeof(InvalidNameSize))]
        [FaultContract(typeof(InvalidIdValue))]
        [FaultContract(typeof(InvalidRemarkValue))]
        [FaultContract(typeof(InvalidRemarkSize))]
        Employee CreateEmployee(int id, string name, string remarks);

        [OperationContract]
        [FaultContract(typeof(ResultNotFoundFault))]
        [FaultContract(typeof(InvalidIdValue))]
        [FaultContract(typeof(InvalidRemarkValue))]
        [FaultContract(typeof(InvalidRemarkSize))]
        void AddRemark(int id, string remarks);

        [OperationContract]
        [FaultContract(typeof(ResultNotFoundFault))]
        void DeleteEmployeeById(int id);

        [OperationContract]
        void DeleteEmployees();
    }
}