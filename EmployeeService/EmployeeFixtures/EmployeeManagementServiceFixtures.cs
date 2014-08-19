using Microsoft.VisualStudio.TestTools.UnitTesting;
using EmployeeFixtures.EmployeeServiceReference;
using System.Diagnostics;
using System.ServiceModel;
using EmployeeFixtures.EmployeeServiceReference;
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
        public void TryCreateEmployeeWithRemark()
        {
            using (var client = new EmployeeManagerClient())
            {
                Employee employee = client.CreateEmployeeWithRemark(1, "Rohit", "New Joinee");
                Assert.AreEqual(1, employee.Id);
            }
        }


        [TestMethod]
        public void TryCreateEmployee()
        {
            using (var client = new EmployeeManagerClient())
            {
                Employee employee = client.CreateEmployee(1, "Rohit");
                Assert.AreEqual(1, employee.Id);
            }
        }

        [TestMethod]
        public void TryAddRemarkForExistingEmployee()
        {
            using (var client = new EmployeeManagerClient())
            {
                Employee employee = client.CreateEmployeeWithRemark(1, "Rohit", "New Joinee");
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
                client.CreateEmployeeWithRemark(1, "Rohit", "New Joinee");
                client.AddRemark(6, "promotted");
            }
        }

        [TestMethod]
        public void TryAddAndRetrieveEmployee()
        {
            using (var employeeManagerClient = new EmployeeManagerClient())
            {
                var employee = employeeManagerClient.CreateEmployeeWithRemark(1, "Rohit", "New Joinee");

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
                employeeManagerClient.CreateEmployeeWithRemark(1, "Rohit", "New Joinee");
                employeeManagerClient.CreateEmployeeWithRemark(1, "Sachin", "New Joinee");
            }
        }


        [TestMethod]
        public void TryGetAllEmployees()
        {
            using (var employeeManagerClient = new EmployeeManagerClient())
            {
                employeeManagerClient.CreateEmployeeWithRemark(1, "Rohit", "New Joinee");
                employeeManagerClient.CreateEmployeeWithRemark(2, "Sachin", "New Joinee");

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
                var employee = employeeManagerClient.CreateEmployeeWithRemark(1, "Rohit", "New Joinee");

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
                employeeManagerClient.CreateEmployeeWithRemark(1, "Rohit", "New Joinee");

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
                employeeManagerClient.CreateEmployeeWithRemark(1, "Rohit", "New Joinee");
                employeeManagerClient.CreateEmployeeWithRemark(2, "Sachin", "New Joinee");
                employeeManagerClient.CreateEmployeeWithRemark(3, "Vaishnavi", "New Joinee");

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
                employeeManagerClient.CreateEmployeeWithRemark(1, "Rohit", "New Joinee");
                employeeManagerClient.CreateEmployeeWithRemark(2, "Sachin", "New Joinee");
                employeeManagerClient.CreateEmployeeWithRemark(3, "Vaishnavi", "New Joinee");

                employeeManagerClient.DeleteEmployeeById(4);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(FaultException<InvalidNameSizeFault>))]
        public void TryCreateEmployeeRemarkWithInvalidNameSize()
        {
            using (var client = new EmployeeManagerClient())
            {
                client.CreateEmployeeWithRemark(1, "David Earl Frederick", "New Joinee");
            }
        }

        [TestMethod]
        [ExpectedException(typeof(FaultException<InvalidNameValueFault>))]
        public void TryCreateEmployeeRemarkWithInvalidNameValue()
        {
            using (var client = new EmployeeManagerClient())
            {
                client.CreateEmployeeWithRemark(1, "r#$%^12e", "New Joinee");
            }
        }

        [TestMethod]
        [ExpectedException(typeof(FaultException<InvalidIdValueFault>))]
        public void TryCreateEmployeeRemarkWithInvalidIdValue()
        {
            using (var client = new EmployeeManagerClient())
            {
                client.CreateEmployeeWithRemark(-1, "Rohit", "New Joinee");
            }
        }

        [TestMethod]
        [ExpectedException(typeof(FaultException<InvalidNameValueFault>))]
        public void TryCreateEmployeeRemarkWithNullNameParameter()
        {
            using (var client = new EmployeeManagerClient())
            {
                client.CreateEmployeeWithRemark(1, null, "New Joinee");
            }
        }

        [TestMethod]
        [ExpectedException(typeof(FaultException<InvalidRemarkValueFault>))]
        public void TryCreateEmployeeRemarkWithNullRemarkParameter()
        {
            using (var client = new EmployeeManagerClient())
            {
                client.CreateEmployeeWithRemark(1, "Rohit", null);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(FaultException<InvalidRemarkSizeFault>))]
        public void TryCreateEmployeeRemarkWithInvalidRemarkSize()
        {
            using (var client = new EmployeeManagerClient())
            {
                client.CreateEmployeeWithRemark(1, "Rohit", "This remark is to validate the length of remark for a particular employee which should not be greater thatn 30 letters");
            }
        }

        [TestMethod]
        [ExpectedException(typeof(FaultException<InvalidNameSizeFault>))]
        public void TryCreateEmployeeInvalidNameSize()
        {
            using (var client = new EmployeeManagerClient())
            {
                client.CreateEmployee(1, "David Earl Frederick");
            }
        }

        [TestMethod]
        [ExpectedException(typeof(FaultException<InvalidNameValueFault>))]
        public void TryCreateEmployeeWithInvalidNameValue()
        {
            using (var client = new EmployeeManagerClient())
            {
                client.CreateEmployee(1, "r#$%^12e");
            }
        }

        [TestMethod]
        [ExpectedException(typeof(FaultException<InvalidIdValueFault>))]
        public void TryCreateEmployeeWithInvalidIdValue()
        {
            using (var client = new EmployeeManagerClient())
            {
                client.CreateEmployee(-1, "Rohit");
            }
        }

        [TestMethod]
        [ExpectedException(typeof(FaultException<InvalidNameValueFault>))]
        public void TryCreateEmployeeWithNullNameParameter()
        {
            using (var client = new EmployeeManagerClient())
            {
                client.CreateEmployee(1, null);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(FaultException<InvalidRemarkValueFault>))]
        public void TryAddRemarkWithNullRemarkParameter()
        {
            using (var client = new EmployeeManagerClient())
            {
                client.AddRemark(1, null);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(FaultException<InvalidRemarkSizeFault>))]
        public void TryAddRemarkWithInvalidRemarkSize()
        {
            using (var client = new EmployeeManagerClient())
            {
                client.AddRemark(1, "This remark is to validate the length of remark for a particular employee which should not be greater thatn 30 letters");
            }
        }

        [TestMethod]
        [ExpectedException(typeof(FaultException<InvalidIdValueFault>))]
        public void TryAddRemarkWithInvalidIdValue()
        {
            using (var client = new EmployeeManagerClient())
            {
                client.AddRemark(0, "New Joinee");
            }
        }

        [TestMethod]
        [ExpectedException(typeof(FaultException<InvalidIdValueFault>))]
        public void TryDeleteEmployeeByIdWithInvalidIdValue()
        {
            using (var client = new EmployeeManagerClient())
            {
                client.DeleteEmployeeById(0);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(FaultException<InvalidIdValueFault>))]
        public void TryGetEmployeeDetailsByIdWithInvalidIdValue()
        {
            using (var client = new EmployeeReaderClient())
            {
                client.GetEmployeeDetailsById(0);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(FaultException<InvalidNameSizeFault>))]
        public void TryGetEmployeesByNameWithInvalidNameSize()
        {
            using (var client = new EmployeeReaderClient())
            {
                client.GetEmployeesByName("David Earl Frederick");
            }
        }

        [TestMethod]
        [ExpectedException(typeof(FaultException<InvalidNameValueFault>))]
        public void TryGetEmployeesByNameWithInvalidNameValue()
        {
            using (var client = new EmployeeReaderClient())
            {
                client.GetEmployeesByName("r#$%^12e");
            }
        }

        [TestMethod]
        [ExpectedException(typeof(FaultException<InvalidNameValueFault>))]
        public void TryGetEmployeesByNameWithNullNameParameter()
        {
            using (var client = new EmployeeReaderClient())
            {
                client.GetEmployeesByName(null);
            }
        }

        [TestMethod]
        public void TryGetEmployeesWithRemark()
        {
            using (var employeeManagerClient = new EmployeeManagerClient())
            {
                employeeManagerClient.CreateEmployeeWithRemark(1, "Rohit", "New Joinee");
                employeeManagerClient.CreateEmployee(2, "Sachin");
                employeeManagerClient.CreateEmployeeWithRemark(3, "Vaishnavi", "New Joinee");

                using (var employeeReaderClient = new EmployeeReaderClient())
                {
                    Assert.AreEqual(2, employeeReaderClient.GetEmployeesWithRemark().Count);
                }
            }
        }

        [TestMethod]
        [ExpectedException(typeof(FaultException<ResultNotFoundFault>))]
        public void TryGetEmployeesWithRemarkForNoResultFound()
        {
            using (var employeeManagerClient = new EmployeeManagerClient())
            {
                employeeManagerClient.CreateEmployee(1, "Rohit");
                employeeManagerClient.CreateEmployee(2, "Sachin");
                employeeManagerClient.CreateEmployee(3, "Vaishnavi");

                using (var employeeReaderClient = new EmployeeReaderClient())
                {
                    employeeReaderClient.GetEmployeesWithRemark();
                }
            }
        }

        [TestMethod]
        [ExpectedException(typeof(FaultException<ResultNotFoundFault>))]
        public void TryDeleteAll()
        {
            using (var employeeManagerClient = new EmployeeManagerClient())
            {
                employeeManagerClient.CreateEmployeeWithRemark(1, "Rohit", "New Joinee");
                employeeManagerClient.CreateEmployeeWithRemark(2, "Sumit", "New Joinee");
              
                using (var employeeReaderClient = new EmployeeReaderClient())
                {
                    var employeeCountBeforeDelete = employeeReaderClient.GetAllEmployees().Count;
                   
                    Assert.AreEqual(2, employeeCountBeforeDelete);
                   
                    employeeManagerClient.DeleteEmployees();

                    employeeReaderClient.GetAllEmployees();
                }
            }
        }
    }
}
