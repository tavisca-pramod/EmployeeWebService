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
        private TestContext testContextInstance;

        public TestContext TestContext
        {
            get { return testContextInstance; }
            set { testContextInstance = value; }
        }

        [TestInitialize]
        public void InitEmployeeServiceFixture()
        {
            using (var client = new EmployeeManagerClient())
            {
                client.DeleteEmployees();
            }
        }

        [TestMethod]
        [DeploymentItem("EmployeeTestDataSource.xml")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML",
                   "EmployeeTestDataSource.xml",
                   "CreateEmployee",
                    DataAccessMethod.Sequential)]
        public void TryCreateEmployeeWithRemark()
        {
            var id = Int32.Parse(testContextInstance.DataRow["EmployeeId"].ToString());
            var name = testContextInstance.DataRow["EmployeeName"].ToString();
            var remark = testContextInstance.DataRow["EmployeeRemark"].ToString();

            using (var client = new EmployeeManagerClient())
            {
                Employee employee = client.CreateEmployeeWithRemark(id, name, remark);
                Assert.AreEqual(1, employee.Id);
            }
        }

        [TestMethod]
        [DeploymentItem("EmployeeTestDataSource.xml")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML",
                   "EmployeeTestDataSource.xml",
                   "CreateEmployee",
                    DataAccessMethod.Sequential)]
        public void TryCreateEmployee()
        {
            var id = Int32.Parse(testContextInstance.DataRow["EmployeeId"].ToString());
            var name = testContextInstance.DataRow["EmployeeName"].ToString();
            using (var client = new EmployeeManagerClient())
            {
                Employee employee = client.CreateEmployee(id, name);
                Assert.AreEqual(id, employee.Id);
            }
        }

        [TestMethod]
        [DeploymentItem("EmployeeTestDataSource.xml")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML",
                   "EmployeeTestDataSource.xml",
                   "AddRemarkForExisting",
                    DataAccessMethod.Sequential)]
        public void TryAddRemarkForExistingEmployee()
        {
            var id = Int32.Parse(testContextInstance.DataRow["EmployeeId"].ToString());
            var name = testContextInstance.DataRow["EmployeeName"].ToString();
            var remark = testContextInstance.DataRow["EmployeeRemark"].ToString();
            var remarkToBeAdded = testContextInstance.DataRow["EmployeeRemark"].ToString();

            using (var client = new EmployeeManagerClient())
            {
                Employee employee = client.CreateEmployeeWithRemark(id, name, remark);
                client.AddRemark(id, remarkToBeAdded);

                using (var readerClient = new EmployeeReaderClient())
                {
                    var employeeWithRemarks = readerClient.GetEmployeeDetailsById(1);
                    Assert.AreEqual(2, employeeWithRemarks.Remarks.Count);
                }
            }
        }

        [TestMethod]
        [DeploymentItem("EmployeeTestDataSource.xml")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML",
                   "EmployeeTestDataSource.xml",
                   "AddRemarkForNonExisting",
                    DataAccessMethod.Sequential)]
        [ExpectedException(typeof(FaultException<ResultNotFoundFault>))]
        public void TryAddRemarkForNonExistingEmployee()
        {
            var id = Int32.Parse(testContextInstance.DataRow["EmployeeId"].ToString());
            var name = testContextInstance.DataRow["EmployeeName"].ToString();
            var remark = testContextInstance.DataRow["EmployeeRemark"].ToString();
            var remarkToBeAdded = testContextInstance.DataRow["EmployeeRemark"].ToString();
            var employeeIdToAddRemark = Int32.Parse(testContextInstance.DataRow["EmployeeIdToAddRemark"].ToString());

            using (var client = new EmployeeManagerClient())
            {
                client.CreateEmployeeWithRemark(id, name, remark);
                client.AddRemark(employeeIdToAddRemark, remarkToBeAdded);
            }
        }

        [TestMethod]
        [DeploymentItem("EmployeeTestDataSource.xml")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML",
                   "EmployeeTestDataSource.xml",
                   "CreateEmployee",
                    DataAccessMethod.Sequential)]
        public void TryAddAndRetrieveEmployee()
        {
            var id = Int32.Parse(testContextInstance.DataRow["EmployeeId"].ToString());
            var name = testContextInstance.DataRow["EmployeeName"].ToString();
            var remark = testContextInstance.DataRow["EmployeeRemark"].ToString();

            using (var employeeManagerClient = new EmployeeManagerClient())
            {
                var employee = employeeManagerClient.CreateEmployeeWithRemark(id, name, remark);

                using (var employeeReaderClient = new EmployeeReaderClient())
                {
                    var employeeReceived = employeeReaderClient.GetEmployeeDetailsById(1);
                    Assert.AreEqual(employee.Id, employeeReceived.Id);
                }
            }
        }

        [TestMethod]
        [DeploymentItem("EmployeeTestDataSource.xml")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML",
                   "EmployeeTestDataSource.xml",
                   "CreateEmployee",
                    DataAccessMethod.Sequential)]
        [ExpectedException(typeof(FaultException<EmployeeAlreadyExistsFault>))]
        public void TryAddExistingEmployee()
        {
            var id = Int32.Parse(testContextInstance.DataRow["EmployeeId"].ToString());
            var name = testContextInstance.DataRow["EmployeeName"].ToString();
            var remark = testContextInstance.DataRow["EmployeeRemark"].ToString();

            using (var employeeManagerClient = new EmployeeManagerClient())
            {
                employeeManagerClient.CreateEmployeeWithRemark(id, name, remark);
                employeeManagerClient.CreateEmployeeWithRemark(id, name, remark);
            }
        }


        [TestMethod]
        [DeploymentItem("EmployeeTestDataSource.xml")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML",
                   "EmployeeTestDataSource.xml",
                   "Employees",
                    DataAccessMethod.Sequential)]
        public void TryGetAllEmployees()
        {
            var id = Int32.Parse(testContextInstance.DataRow["EmployeeId"].ToString());
            var name = testContextInstance.DataRow["EmployeeName"].ToString();
            var remark = testContextInstance.DataRow["EmployeeRemark"].ToString();

            var employeeId = Int32.Parse(testContextInstance.DataRow["SecondEmployeeId"].ToString());
            var employeeName = testContextInstance.DataRow["SecondEmployeeName"].ToString();

            using (var employeeManagerClient = new EmployeeManagerClient())
            {
                employeeManagerClient.CreateEmployeeWithRemark(id, name, remark);
                employeeManagerClient.CreateEmployeeWithRemark(employeeId, employeeName, remark);

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
        [DeploymentItem("EmployeeTestDataSource.xml")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML",
                   "EmployeeTestDataSource.xml",
                   "CreateEmployee",
                    DataAccessMethod.Sequential)]
        public void TryGetEmployeesByName()
        {
            var id = Int32.Parse(testContextInstance.DataRow["EmployeeId"].ToString());
            var name = testContextInstance.DataRow["EmployeeName"].ToString();
            var remark = testContextInstance.DataRow["EmployeeRemark"].ToString();

            using (var employeeManagerClient = new EmployeeManagerClient())
            {
                var employee = employeeManagerClient.CreateEmployeeWithRemark(id, name, remark);

                using (var employeeReaderClient = new EmployeeReaderClient())
                {
                    var employeees = employeeReaderClient.GetEmployeesByName(name);
                    Assert.IsTrue(employeees.Any(emp => emp.Id == employee.Id));
                }
            }
        }


        [TestMethod]
        [DeploymentItem("EmployeeTestDataSource.xml")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML",
                   "EmployeeTestDataSource.xml",
                   "Employees",
                    DataAccessMethod.Sequential)]
        [ExpectedException(typeof(FaultException<ResultNotFoundFault>))]
        public void TryGetEmployeesByNameForNonExistingEmployee()
        {
            var id = Int32.Parse(testContextInstance.DataRow["EmployeeId"].ToString());
            var name = testContextInstance.DataRow["EmployeeName"].ToString();
            var remark = testContextInstance.DataRow["EmployeeRemark"].ToString();

            var employeeName = testContextInstance.DataRow["SecondEmployeeName"].ToString();

            using (var employeeManagerClient = new EmployeeManagerClient())
            {
                employeeManagerClient.CreateEmployeeWithRemark(id, name, remark);

                using (var employeeReaderClient = new EmployeeReaderClient())
                {
                    employeeReaderClient.GetEmployeesByName(employeeName);
                }
            }
        }


        [TestMethod]
        [DeploymentItem("EmployeeTestDataSource.xml")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML",
                   "EmployeeTestDataSource.xml",
                   "Employees",
                    DataAccessMethod.Sequential)]
        public void TryDeleteEmployee()
        {
            var id = Int32.Parse(testContextInstance.DataRow["EmployeeId"].ToString());
            var name = testContextInstance.DataRow["EmployeeName"].ToString();
            var remark = testContextInstance.DataRow["EmployeeRemark"].ToString();

            var employeeId = Int32.Parse(testContextInstance.DataRow["SecondEmployeeId"].ToString());
            var employeeName = testContextInstance.DataRow["SecondEmployeeName"].ToString();

            using (var employeeManagerClient = new EmployeeManagerClient())
            {
                employeeManagerClient.CreateEmployeeWithRemark(id, name, remark);
                employeeManagerClient.CreateEmployeeWithRemark(employeeId, employeeName, remark);

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
        [DeploymentItem("EmployeeTestDataSource.xml")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML",
                   "EmployeeTestDataSource.xml",
                   "DeleteNonExistingEmployee",
                    DataAccessMethod.Sequential)]
        [ExpectedException(typeof(FaultException<ResultNotFoundFault>))]
        public void TryDeleteNonExistingEmployee()
        {
            var id = Int32.Parse(testContextInstance.DataRow["EmployeeId"].ToString());
            var name = testContextInstance.DataRow["EmployeeName"].ToString();
            var remark = testContextInstance.DataRow["EmployeeRemark"].ToString();

            var employeeId = Int32.Parse(testContextInstance.DataRow["SecondEmployeeId"].ToString());
            var employeeName = testContextInstance.DataRow["SecondEmployeeName"].ToString();

            var employeeIdToDelete = Int32.Parse(testContextInstance.DataRow["EmployeeIdToDelete"].ToString());
            using (var employeeManagerClient = new EmployeeManagerClient())
            {
                employeeManagerClient.CreateEmployeeWithRemark(id, name, remark);
                employeeManagerClient.CreateEmployeeWithRemark(employeeId, employeeName, remark);

                employeeManagerClient.DeleteEmployeeById(employeeIdToDelete);
            }
        }

        [TestMethod]
        [DeploymentItem("EmployeeTestDataSource.xml")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML",
                   "EmployeeTestDataSource.xml",
                   "EmployeeWithInvalidNameSize",
                    DataAccessMethod.Sequential)]
        [ExpectedException(typeof(FaultException<InvalidNameSizeFault>))]
        public void TryCreateEmployeeRemarkWithInvalidNameSize()
        {
            var id = Int32.Parse(testContextInstance.DataRow["EmployeeId"].ToString());
            var name = testContextInstance.DataRow["EmployeeName"].ToString();
            var remark = testContextInstance.DataRow["EmployeeRemark"].ToString();
            using (var client = new EmployeeManagerClient())
            {
                client.CreateEmployeeWithRemark(id, name, remark);
            }
        }

        [TestMethod]
        [DeploymentItem("EmployeeTestDataSource.xml")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML",
                   "EmployeeTestDataSource.xml",
                   "EmployeeWithInvalidNameValue",
                    DataAccessMethod.Sequential)]
        [ExpectedException(typeof(FaultException<InvalidNameValueFault>))]
        public void TryCreateEmployeeRemarkWithInvalidNameValue()
        {
            var id = Int32.Parse(testContextInstance.DataRow["EmployeeId"].ToString());
            var name = testContextInstance.DataRow["EmployeeName"].ToString();
            var remark = testContextInstance.DataRow["EmployeeRemark"].ToString();
            using (var client = new EmployeeManagerClient())
            {
                client.CreateEmployeeWithRemark(id, name, remark);
            }
        }

        [TestMethod]
        [DeploymentItem("EmployeeTestDataSource.xml")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML",
                   "EmployeeTestDataSource.xml",
                   "EmployeeWithInvalidIdValue",
                    DataAccessMethod.Sequential)]
        [ExpectedException(typeof(FaultException<InvalidIdValueFault>))]
        public void TryCreateEmployeeRemarkWithInvalidIdValue()
        {
            var id = Int32.Parse(testContextInstance.DataRow["EmployeeId"].ToString());
            var name = testContextInstance.DataRow["EmployeeName"].ToString();
            var remark = testContextInstance.DataRow["EmployeeRemark"].ToString();
            using (var client = new EmployeeManagerClient())
            {
                client.CreateEmployeeWithRemark(id, name, remark);
            }
        }

        [TestMethod]
        [DeploymentItem("EmployeeTestDataSource.xml")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML",
                   "EmployeeTestDataSource.xml",
                   "CreateEmployee",
                    DataAccessMethod.Sequential)]
        [ExpectedException(typeof(FaultException<InvalidNameValueFault>))]
        public void TryCreateEmployeeRemarkWithNullNameParameter()
        {
            var id = Int32.Parse(testContextInstance.DataRow["EmployeeId"].ToString());
            var remark = testContextInstance.DataRow["EmployeeRemark"].ToString();
            using (var client = new EmployeeManagerClient())
            {
                client.CreateEmployeeWithRemark(id, null, remark);
            }
        }

        [TestMethod]
        [DeploymentItem("EmployeeTestDataSource.xml")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML",
                   "EmployeeTestDataSource.xml",
                   "CreateEmployee",
                    DataAccessMethod.Sequential)]
        [ExpectedException(typeof(FaultException<InvalidRemarkValueFault>))]
        public void TryCreateEmployeeRemarkWithNullRemarkParameter()
        {
            var id = Int32.Parse(testContextInstance.DataRow["EmployeeId"].ToString());
            var name = testContextInstance.DataRow["EmployeeName"].ToString();
            using (var client = new EmployeeManagerClient())
            {
                client.CreateEmployeeWithRemark(id, name, null);
            }
        }

        [TestMethod]
        [DeploymentItem("EmployeeTestDataSource.xml")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML",
                   "EmployeeTestDataSource.xml",
                   "EmployeeWithInvalidRemarkSize",
                    DataAccessMethod.Sequential)]
        [ExpectedException(typeof(FaultException<InvalidRemarkSizeFault>))]
        public void TryCreateEmployeeRemarkWithInvalidRemarkSize()
        {
            var id = Int32.Parse(testContextInstance.DataRow["EmployeeId"].ToString());
            var name = testContextInstance.DataRow["EmployeeName"].ToString();
            var remark = testContextInstance.DataRow["EmployeeRemark"].ToString();

            using (var client = new EmployeeManagerClient())
            {
                client.CreateEmployeeWithRemark(id, name, remark);
            }
        }

        [TestMethod]
        [DeploymentItem("EmployeeTestDataSource.xml")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML",
                   "EmployeeTestDataSource.xml",
                   "EmployeeWithInvalidNameSize",
                    DataAccessMethod.Sequential)]
        [ExpectedException(typeof(FaultException<InvalidNameSizeFault>))]
        public void TryCreateEmployeeInvalidNameSize()
        {
            var id = Int32.Parse(testContextInstance.DataRow["EmployeeId"].ToString());
            var name = testContextInstance.DataRow["EmployeeName"].ToString();

            using (var client = new EmployeeManagerClient())
            {
                client.CreateEmployee(id, name);
            }
        }

        [TestMethod]
        [DeploymentItem("EmployeeTestDataSource.xml")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML",
                   "EmployeeTestDataSource.xml",
                   "EmployeeWithInvalidNameValue",
                    DataAccessMethod.Sequential)]
        [ExpectedException(typeof(FaultException<InvalidNameValueFault>))]
        public void TryCreateEmployeeWithInvalidNameValue()
        {
            var id = Int32.Parse(testContextInstance.DataRow["EmployeeId"].ToString());
            var name = testContextInstance.DataRow["EmployeeName"].ToString();

            using (var client = new EmployeeManagerClient())
            {
                client.CreateEmployee(id, name);
            }
        }

        [TestMethod]
        [DeploymentItem("EmployeeTestDataSource.xml")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML",
                   "EmployeeTestDataSource.xml",
                   "EmployeeWithInvalidIdValue",
                    DataAccessMethod.Sequential)]
        [ExpectedException(typeof(FaultException<InvalidIdValueFault>))]
        public void TryCreateEmployeeWithInvalidIdValue()
        {
            var id = Int32.Parse(testContextInstance.DataRow["EmployeeId"].ToString());
            var name = testContextInstance.DataRow["EmployeeName"].ToString();
            using (var client = new EmployeeManagerClient())
            {
                client.CreateEmployee(id, name);
            }
        }

        [TestMethod]
        [DeploymentItem("EmployeeTestDataSource.xml")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML",
                   "EmployeeTestDataSource.xml",
                   "CreateEmployee",
                    DataAccessMethod.Sequential)]
        [ExpectedException(typeof(FaultException<InvalidNameValueFault>))]
        public void TryCreateEmployeeWithNullNameParameter()
        {
            var id = Int32.Parse(testContextInstance.DataRow["EmployeeId"].ToString());
            using (var client = new EmployeeManagerClient())
            {
                client.CreateEmployee(id, null);
            }
        }

        [TestMethod]
        [DeploymentItem("EmployeeTestDataSource.xml")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML",
                   "EmployeeTestDataSource.xml",
                   "CreateEmployee",
                    DataAccessMethod.Sequential)]
        [ExpectedException(typeof(FaultException<InvalidRemarkValueFault>))]
        public void TryAddRemarkWithNullRemarkParameter()
        {
            var id = Int32.Parse(testContextInstance.DataRow["EmployeeId"].ToString());
            using (var client = new EmployeeManagerClient())
            {
                client.AddRemark(id, null);
            }
        }

        [TestMethod]
        [DeploymentItem("EmployeeTestDataSource.xml")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML",
                   "EmployeeTestDataSource.xml",
                   "EmployeeWithInvalidRemarkSize",
                    DataAccessMethod.Sequential)]
        [ExpectedException(typeof(FaultException<InvalidRemarkSizeFault>))]
        public void TryAddRemarkWithInvalidRemarkSize()
        {
            var id = Int32.Parse(testContextInstance.DataRow["EmployeeId"].ToString());
            var remark = testContextInstance.DataRow["EmployeeRemark"].ToString();

            using (var client = new EmployeeManagerClient())
            {
                client.AddRemark(id, remark);
            }
        }

        [TestMethod]
        [DeploymentItem("EmployeeTestDataSource.xml")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML",
                   "EmployeeTestDataSource.xml",
                   "EmployeeWithInvalidIdValue",
                    DataAccessMethod.Sequential)]
        [ExpectedException(typeof(FaultException<InvalidIdValueFault>))]
        public void TryAddRemarkWithInvalidIdValue()
        {
            var id = Int32.Parse(testContextInstance.DataRow["EmployeeId"].ToString());
            var remark = testContextInstance.DataRow["EmployeeRemark"].ToString();

            using (var client = new EmployeeManagerClient())
            {
                client.AddRemark(id, remark);
            }
        }

        [TestMethod]
        [DeploymentItem("EmployeeTestDataSource.xml")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML",
                   "EmployeeTestDataSource.xml",
                   "EmployeeWithInvalidIdValue",
                    DataAccessMethod.Sequential)]
        [ExpectedException(typeof(FaultException<InvalidIdValueFault>))]
        public void TryDeleteEmployeeByIdWithInvalidIdValue()
        {
            var id = Int32.Parse(testContextInstance.DataRow["EmployeeId"].ToString());

            using (var client = new EmployeeManagerClient())
            {
                client.DeleteEmployeeById(id);
            }
        }

        [TestMethod]
        [DeploymentItem("EmployeeTestDataSource.xml")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML",
                   "EmployeeTestDataSource.xml",
                   "EmployeeWithInvalidIdValue",
                    DataAccessMethod.Sequential)]
        [ExpectedException(typeof(FaultException<InvalidIdValueFault>))]
        public void TryGetEmployeeDetailsByIdWithInvalidIdValue()
        {
            var id = Int32.Parse(testContextInstance.DataRow["EmployeeId"].ToString());

            using (var client = new EmployeeReaderClient())
            {
                client.GetEmployeeDetailsById(id);
            }
        }

        [TestMethod]
        [DeploymentItem("EmployeeTestDataSource.xml")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML",
                   "EmployeeTestDataSource.xml",
                   "EmployeeWithInvalidNameSize",
                    DataAccessMethod.Sequential)]
        [ExpectedException(typeof(FaultException<InvalidNameSizeFault>))]
        public void TryGetEmployeesByNameWithInvalidNameSize()
        {
            var name = testContextInstance.DataRow["EmployeeName"].ToString();

            using (var client = new EmployeeReaderClient())
            {
                client.GetEmployeesByName(name);
            }
        }

        [TestMethod]
        [DeploymentItem("EmployeeTestDataSource.xml")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML",
                   "EmployeeTestDataSource.xml",
                   "EmployeeWithInvalidNameValue",
                    DataAccessMethod.Sequential)]
        [ExpectedException(typeof(FaultException<InvalidNameValueFault>))]
        public void TryGetEmployeesByNameWithInvalidNameValue()
        {
            var name = testContextInstance.DataRow["EmployeeName"].ToString();

            using (var client = new EmployeeReaderClient())
            {
                client.GetEmployeesByName(name);
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
        [DeploymentItem("EmployeeTestDataSource.xml")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML",
                   "EmployeeTestDataSource.xml",
                   "Employees",
                    DataAccessMethod.Sequential)]
        public void TryGetEmployeesWithRemark()
        {
            var id = Int32.Parse(testContextInstance.DataRow["EmployeeId"].ToString());
            var name = testContextInstance.DataRow["EmployeeName"].ToString();
            var remark = testContextInstance.DataRow["EmployeeRemark"].ToString();

            var employeeId = Int32.Parse(testContextInstance.DataRow["SecondEmployeeId"].ToString());
            var employeeName = testContextInstance.DataRow["SecondEmployeeName"].ToString();
            var employeeCountWithRemark = Int32.Parse(testContextInstance.DataRow["EmployeeCountWithRemark"].ToString());

            using (var employeeManagerClient = new EmployeeManagerClient())
            {
                employeeManagerClient.CreateEmployeeWithRemark(id, name, remark);
                employeeManagerClient.CreateEmployee(employeeId, employeeName);

                using (var employeeReaderClient = new EmployeeReaderClient())
                {
                    Assert.AreEqual(employeeCountWithRemark, employeeReaderClient.GetEmployeesWithRemark().Count);
                }
            }
        }

        [TestMethod]
        [DeploymentItem("EmployeeTestDataSource.xml")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML",
                   "EmployeeTestDataSource.xml",
                   "Employees",
                    DataAccessMethod.Sequential)]
        [ExpectedException(typeof(FaultException<ResultNotFoundFault>))]
        public void TryGetEmployeesWithRemarkForNoResultFound()
        {
            var id = Int32.Parse(testContextInstance.DataRow["EmployeeId"].ToString());
            var name = testContextInstance.DataRow["EmployeeName"].ToString();
        
            var employeeId = Int32.Parse(testContextInstance.DataRow["SecondEmployeeId"].ToString());
            var employeeName = testContextInstance.DataRow["SecondEmployeeName"].ToString();
        
            using (var employeeManagerClient = new EmployeeManagerClient())
            {
                employeeManagerClient.CreateEmployee(id,name);
                employeeManagerClient.CreateEmployee(employeeId, employeeName);
                
                using (var employeeReaderClient = new EmployeeReaderClient())
                {
                    employeeReaderClient.GetEmployeesWithRemark();
                }
            }
        }

        [TestMethod]
        [DeploymentItem("EmployeeTestDataSource.xml")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML",
                   "EmployeeTestDataSource.xml",
                   "Employees",
                    DataAccessMethod.Sequential)]
        [ExpectedException(typeof(FaultException<ResultNotFoundFault>))]
        public void TryDeleteAll()
        {
            var id = Int32.Parse(testContextInstance.DataRow["EmployeeId"].ToString());
            var name = testContextInstance.DataRow["EmployeeName"].ToString();
            var remark = testContextInstance.DataRow["EmployeeRemark"].ToString();

            var employeeId = Int32.Parse(testContextInstance.DataRow["SecondEmployeeId"].ToString());
            var employeeName = testContextInstance.DataRow["SecondEmployeeName"].ToString();
            var totalEmployees = Int32.Parse(testContextInstance.DataRow["TotalNumberOfEmployees"].ToString());
            
            using (var employeeManagerClient = new EmployeeManagerClient())
            {
                employeeManagerClient.CreateEmployeeWithRemark(id, name, remark);
                employeeManagerClient.CreateEmployeeWithRemark(employeeId,employeeName, remark);

                using (var employeeReaderClient = new EmployeeReaderClient())
                {
                    var employeeCountBeforeDelete = employeeReaderClient.GetAllEmployees().Count;

                    Assert.AreEqual(totalEmployees, employeeCountBeforeDelete);

                    employeeManagerClient.DeleteEmployees();

                    employeeReaderClient.GetAllEmployees();
                }
            }
        }
    }
}
