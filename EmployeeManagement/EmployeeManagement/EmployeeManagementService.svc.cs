using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace EmployeeManagement
{

    public class EmployeeManagementService : IEmployeeReader, IEmployeeWriter
    {
        public Employee GetEmployee(long employeeId)
        {
            return null;
        }

        public List<Employee> GetEmployees(string employeeName)
        {
            return null;
        }

        public void createEmployee(Employee employee)
        {
            return;
        }

        public void addRemarksToEmplyee(long employeeId)
        {
            return;
        }

        public List<Employee> GetEmployees()
        {
            return null;
        }

        public List<Employee> GetEmployeesWithRemarks()
        {
            return null;
        }
    }
}
