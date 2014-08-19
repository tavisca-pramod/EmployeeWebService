using System.ServiceModel;

namespace EmployeeService
{
    [ServiceContract]
    public interface IEmployeeManager
    {
        [OperationContract(Name = "CreateEmployeeWithRemark")]
        [FaultContract(typeof(EmployeeAlreadyExistsFault))]
        [FaultContract(typeof(InvalidNameValueFault))]
        [FaultContract(typeof(InvalidNameSizeFault))]
        [FaultContract(typeof(InvalidIdValueFault))]
        [FaultContract(typeof(InvalidRemarkValueFault))]
        [FaultContract(typeof(InvalidRemarkSizeFault))]
        Employee CreateEmployee(int id, string name, string remarks);

        [OperationContract(Name = "CreateEmployee")]
        [FaultContract(typeof(EmployeeAlreadyExistsFault))]
        [FaultContract(typeof(InvalidNameValueFault))]
        [FaultContract(typeof(InvalidNameSizeFault))]
        [FaultContract(typeof(InvalidIdValueFault))]
        Employee CreateEmployee(int id, string name);


        [OperationContract]
        [FaultContract(typeof(ResultNotFoundFault))]
        [FaultContract(typeof(InvalidIdValueFault))]
        [FaultContract(typeof(InvalidRemarkValueFault))]
        [FaultContract(typeof(InvalidRemarkSizeFault))]
        void AddRemark(int id, string remarks);

        [OperationContract]
        [FaultContract(typeof(ResultNotFoundFault))]
        [FaultContract(typeof(InvalidIdValueFault))]
        void DeleteEmployeeById(int id);

        [OperationContract]
        void DeleteEmployees();
    }
}