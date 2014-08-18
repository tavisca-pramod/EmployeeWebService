using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Web;
using System.Text;

namespace EmployeeManagement
{

    public class EmployeeManagementService : IEmployeeReader, IEmployeeWriter
    {
        public Employee GetEmployee(long employeeId)
        {
            return EmployeeData.EmployeeList.Single(x => x.Id.Equals(employeeId));
        }

        public List<Employee> GetEmployees(string employeeName)
        {
            return EmployeeData.EmployeeList.FindAll(x => x.Name.Equals(employeeName));
        }

        public List<Employee> GetEmployees()
        {
            return EmployeeData.EmployeeList;
        }

        public List<Employee> GetEmployeesWithRemarks()
        {
            return EmployeeData.EmployeeList.FindAll(x => x.Remarks.Count > 0);
        }
        
        public void CreateEmployee(Employee employee, Remark remark)
        {
            if (EmployeeData.EmployeeList.Contains(employee))
            {
                throw FaultException.CreateFault(
                   MessageFault.CreateFault(
                   new FaultCode("101"), "Employee with Id " + employee.Id + " already exists. "));
            }
            
            employee.Remarks = new List<Remark>();
            employee.Remarks.Add(remark);
            EmployeeData.EmployeeList.Add(employee);
        }

        public void AddRemarksToEmplyee(long employeeId, Remark remark)
        {
            var employee = EmployeeData.EmployeeList.First(x => x.Id.Equals(employeeId));
            employee.Remarks.Add(remark);
            EmployeeData.EmployeeList.Remove(employee);
            EmployeeData.EmployeeList.Add(employee);
        }
    }
}
