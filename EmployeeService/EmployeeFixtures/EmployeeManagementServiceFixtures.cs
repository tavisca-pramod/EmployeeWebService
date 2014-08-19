using Microsoft.VisualStudio.TestTools.UnitTesting;
using EmployeeFixtures.EmployeeServiceReference;
using System.Diagnostics;
using System.ServiceModel;
using EmployeeAlreadyExistsFault = EmployeeFixtures.EmployeeServiceReference.EmployeeAlreadyExistsFault;
using ResultNotFoundFault = EmployeeFixtures.EmployeeServiceReference.ResultNotFoundFault;
using System.Linq;
using System;

namespace EmployeeFixtures
{

    [TestClass]
    public class EmployeeManagementServiceFixtures
    {
        [TestInitialize]
        public void InitEmployeeServiceFixture()
        {
            using (var client = new EmployeeManagerClient())
            {
                client.DeleteEmployees();
            }
        }

        [TestMethod]
        public void TryCreateEmployee()
        {
            using (var client = new EmployeeManagerClient())
            {
                Employee employee = client.CreateEmployee(1, "Rohit", "New Joinee");
                Assert.AreEqual(1, employee.Id);
            }
        }

        [TestMethod]
        public void TryAddRemarkForExistingEmployee()
        {
            using (var client = new EmployeeManagerClient())
            {
                Employee employee = client.CreateEmployee(1, "Rohit", "New Joinee");
                client.AddRemark(1, "Promoted");

                using (var readerClient = new EmployeeReaderClient())
                {
                    var employeeWithRemarks = readerClient.GetEmployeeDetailsById(1);
                    Assert.AreEqual(2, employeeWithRemarks.Remarks.Count);
                }
            }
        }


        [TestMethod]
        [ExpectedException(typeof(FaultException<ResultNotFoundFault>))]
        public void TryAddRemarkForNonExistingEmployee()
        {
            using (var client = new EmployeeManagerClient())
            {
                client.CreateEmployee(1, "Rohit", "New Joinee");
                client.AddRemark(6, "promotted");
            }
        }

        [TestMethod]
        public void TryAddAndRetrieveEmployee()
        {
            using (var employeeManagerClient = new EmployeeManagerClient())
            {
                var employee = employeeManagerClient.CreateEmployee(1, "Rohit", "New Joinee");

                using (var employeeReaderClient = new EmployeeReaderClient())
                {
                    var employeeReceived = employeeReaderClient.GetEmployeeDetailsById(1);
                    Assert.AreEqual(employee.Id, employeeReceived.Id);
                }
            }
        }

        [TestMethod]
        [ExpectedException(typeof(FaultException<EmployeeAlreadyExistsFault>))]
        public void TryAddExistingEmployee()
        {
            using (var employeeManagerClient = new EmployeeManagerClient())
            {
                employeeManagerClient.CreateEmployee(1, "Rohit", "New Joinee");
                employeeManagerClient.CreateEmployee(1, "Sachin", "New Joinee");
            }
        }


        [TestMethod]
        public void TryGetAllEmployees()
        {
            using (var employeeManagerClient = new EmployeeManagerClient())
            {
                employeeManagerClient.CreateEmployee(1, "Rohit", "New Joinee");
                employeeManagerClient.CreateEmployee(2, "Sachin", "New Joinee");

                using (var employeeReaderClient = new EmployeeReaderClient())
                {
                    var employees = employeeReaderClient.GetAllEmployees();
                    Assert.AreEqual(2, employees.Count);
                }
            }
        }

        [TestMethod]
        [ExpectedException(typeof(FaultException<ResultNotFoundFault>))]
        public void TryGetAllEmployeesForEmptyEmployeeData()
        {
            using (var employeeReaderClient = new EmployeeReaderClient())
            {
                employeeReaderClient.GetAllEmployees();
            }
        }

        [TestMethod]
        public void TryGetEmployeesByName()
        {
            using (var employeeManagerClient = new EmployeeManagerClient())
            {
                var employee = employeeManagerClient.CreateEmployee(1, "Rohit", "New Joinee");

                using (var employeeReaderClient = new EmployeeReaderClient())
                {
                    var employeees = employeeReaderClient.GetEmployeesByName("Rohit");
                    Assert.IsTrue(employeees.Any(emp => emp.Id == employee.Id));
                }
            }
        }


        [TestMethod]
        [ExpectedException(typeof(FaultException<ResultNotFoundFault>))]
        public void TryGetEmployeesByNameForNonExistingEmployee()
        {
            using (var employeeManagerClient = new EmployeeManagerClient())
            {
                employeeManagerClient.CreateEmployee(1, "Rohit", "New Joinee");

                using (var employeeReaderClient = new EmployeeReaderClient())
                {
                    employeeReaderClient.GetEmployeesByName("Sumit");
                }
            }
        }

        [TestMethod]
        public void TryDeleteEmployee()
        {
            using (var employeeManagerClient = new EmployeeManagerClient())
            {
                employeeManagerClient.CreateEmployee(1, "Rohit", "New Joinee");
                employeeManagerClient.CreateEmployee(2, "Sachin", "New Joinee");
                employeeManagerClient.CreateEmployee(3, "Vaishnavi", "New Joinee");

                using (var employeeReaderClient = new EmployeeReaderClient())
                {
                    var employees = employeeReaderClient.GetAllEmployees();

                    employeeManagerClient.DeleteEmployeeById(1);

                    var employeesAfterDelete = employeeReaderClient.GetAllEmployees();
                    Assert.AreEqual(employees.Count, employeesAfterDelete.Count + 1);
                }
            }
        }

        [TestMethod]
        [ExpectedException(typeof(FaultException<ResultNotFoundFault>))]
        public void TryDeleteNonExistingEmployee()
        {
            using (var employeeManagerClient = new EmployeeManagerClient())
            {
                employeeManagerClient.CreateEmployee(1, "Rohit", "New Joinee");
                employeeManagerClient.CreateEmployee(2, "Sachin", "New Joinee");
                employeeManagerClient.CreateEmployee(3, "Vaishnavi", "New Joinee");
                
                employeeManagerClient.DeleteEmployeeById(4);
            }
        }
    }
}
