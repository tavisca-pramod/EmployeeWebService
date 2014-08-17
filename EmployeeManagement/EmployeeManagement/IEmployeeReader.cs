using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;


namespace EmployeeManagement
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IEmployeeReader
    {
        [OperationContract]
        Employee GetEmployee(long employeeId);

        [OperationContract(Name = "GetEmployeesByName")]
        List<Employee> GetEmployees(string employeeName);     

        [OperationContract(Name = "GetAllEmployees")]
        List<Employee> GetEmployees();

        [OperationContract]
        List<Employee> GetEmployeesWithRemarks();
    }    
}