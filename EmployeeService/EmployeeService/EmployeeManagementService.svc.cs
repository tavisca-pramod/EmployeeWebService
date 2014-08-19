using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace EmployeeService
{
    public class EmployeeManagementService : IEmployeeManager, IEmployeeReader
    {
        private static List<Employee> _employees = new List<Employee>();

        public Employee CreateEmployee(int id, string name, string remarkText)
        {
            if (_employees.Any(empolyee => empolyee.Id == id))
            {
                EmployeeAlreadyExistsFault fault = new EmployeeAlreadyExistsFault
                {
                    FaultId = 101,
                    Message = "Employee with Id " + id + " already exists"
                };
                throw new FaultException<EmployeeAlreadyExistsFault>
                    (fault, "Employee with Id " + id + " already exists");
            }

            Employee employee = GetEmployeeObject(id, name, remarkText);

            _employees.Add(employee);

            return employee;
        }

        private static Employee GetEmployeeObject(int id, string name, string remarkText)
        {
            Employee employee = new Employee();
            employee.Id = id;
            employee.Name = name;

            Remark remark = new Remark();
            remark.RemarkText = remarkText;
            remark.RemarkDate = DateTime.Now;

            employee.Remarks = new List<Remark>();
            employee.Remarks.Add(remark);
            return employee;
        }

        public void AddRemark(int id, string remarkText)
        {
            if (_employees.Any(emp => emp.Id == id))
            {
                Employee employee = _employees.Single(emp => emp.Id == id);

                Remark remark = new Remark();
                remark.RemarkDate= DateTime.Now;
                remark.RemarkText= remarkText;
                employee.Remarks.Add(remark);
            }
            else
            {
                ResultNotFoundFault fault = new ResultNotFoundFault
                {
                    FaultId = 102,
                    Message = "Employee with Id "+id+" does not exist"
                };
                throw new FaultException<ResultNotFoundFault>(fault, "Employee with Id " + id + " does not exist");
            }
        }

        public void DeleteEmployeeById(int id)
        {
            if (_employees.Any(emp => emp.Id == id))
            {
                _employees.Remove(_employees.Single(employee => employee.Id == id));
            }
            else
            {
                ResultNotFoundFault fault = new ResultNotFoundFault
                {
                    FaultId = 102,
                    Message = "Employee with Id " + id + " does not exist"
                };
                throw new FaultException<ResultNotFoundFault>(fault, "Employee with Id " + id + " does not exist");
            }
        }

        public Employee GetEmployeeDetailsById(int id)
        {
            if (_employees.Any(emp => emp.Id == id))
            {
                return _employees.Single(emp => emp.Id == id);
            }

            ResultNotFoundFault fault = new ResultNotFoundFault
            {
                FaultId = 102,
                Message = "Employee with Id " + id + " does not exist"
            };

            throw new FaultException<ResultNotFoundFault>(fault, "Employee with Id " + id + " does not exist");
        }

        public List<Employee> GetEmployees()
        {
            if (_employees.Count > 0)
                return _employees;

            ResultNotFoundFault fault = new ResultNotFoundFault
            {
                FaultId = 102,
                Message = "Employees data not found"
            };
            throw new FaultException<ResultNotFoundFault>(fault, "Employees data not found");
        }

        public List<Employee> GetEmployees(string name)
        {
            if (_employees.Any(emp => emp.Name == name))
            {
                return _employees.FindAll(emp => emp.Name == name);                
            }
            else
            {
                ResultNotFoundFault fault = new ResultNotFoundFault
                {
                    FaultId = 103,
                    Message = "Employees with Name "+ name+" not found"
                };
                throw new FaultException<ResultNotFoundFault>(fault, "Employees with Name " + name + " not found");

            }
        }

        public void DeleteEmployees()
        {
            _employees = new List<Employee>();
        }

    }
}