using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace EmployeeManagement
{

    public class EmployeeData
    {
        private static List<Employee> _employeeList = new List<Employee>();

        public static List<Employee> EmployeeList
        {
            get
            {
                return _employeeList;
            }
        }           
    }
}