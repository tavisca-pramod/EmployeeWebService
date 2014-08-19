using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.ServiceModel;
using System.ServiceModel.Configuration;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using EmployeeService;
using System.Text.RegularExpressions;

namespace EmployeeServiceValidatior
{
    public class ValidationParameterInspector : IParameterInspector
    {
        static Regex employeeRegex = new Regex("[a-zA-Z/ ]+[a-zA-Z]$");

        public void AfterCall(string operationName, object[] outputs, object returnValue, object correlationState)
        {

        }

        public object BeforeCall(string operationName, object[] inputs)
        {
            if (operationName == "CreateEmployeeWithRemark")
            {
                ValidateCreateEmployeeWithRemarkCall(inputs);
                return null;
            }
            
            if (operationName == "CreateEmployee")
            {
                ValidateCreateEmployeeCall(inputs);
                return null;
            }

            if (operationName == "AddRemark")
            {
                ValidateAddRemarkCall(inputs);
                return null;
            }
            
            if (operationName == "DeleteEmployeeById")
            {
                ValidateDeleteEmployeeByIdCall(inputs);
                return null;
            }

            if (operationName == "GetEmployeeDetailsById")
            {
                ValidateGetEmployeeDetailsByIdCall(inputs);
                return null;
            }

            if (operationName == "GetEmployeesByName")
            {
                ValidateGetEmployeesByNameCall(inputs);
                return null;
            }

            return null;
        }

        private void ValidateGetEmployeesByNameCall(object[] inputs)
        {
            ValidateEmployeeName((string)inputs[0]);
        }

        private void ValidateGetEmployeeDetailsByIdCall(object[] inputs)
        {
            ValidateEmployeeId((Int32)inputs[0]);
        }

        private void ValidateDeleteEmployeeByIdCall(object[] inputs)
        {
            ValidateEmployeeId((Int32)inputs[0]);
        }

        private void ValidateAddRemarkCall(object[] inputs)
        {
            for (int index = 0; index < inputs.Length; index++)
            {
                if (index == 0)
                {
                    ValidateEmployeeId((Int32)inputs[index]);
                }

                if (index == 1)
                {
                    string remark = (String)inputs[index];

                    ValidateRemark(remark);
                }
            }
        }

        private void ValidateCreateEmployeeWithRemarkCall(object[] inputs)
        {
            for (int index = 0; index < inputs.Length; index++)
            {
                if (index == 0)
                {
                    ValidateEmployeeId((Int32)inputs[index]);
                }

                if (index == 1)
                {
                    string employeeName = (String)inputs[index];

                    ValidateEmployeeName(employeeName);
                }

                if (index == 2)
                {
                    string remark = (String)inputs[index];
                    ValidateRemark(remark);
                }
            }
        }


        private void ValidateCreateEmployeeCall(object[] inputs)
        {
            for (int index = 0; index < inputs.Length; index++)
            {
                if (index == 0)
                {
                    ValidateEmployeeId((Int32)inputs[index]);
                }

                if (index == 1)
                {
                    string employeeName = (String)inputs[index];

                    ValidateEmployeeName(employeeName);
                }
            }
        }


        private void ValidateRemark(string remark)
        {
            ValidateRemarkName(remark);
            ValidateRemarkSize(remark);
        }

        private void ValidateEmployeeName(string employeeName)
        {
            ValidateEmptyEmployeeName(employeeName);
            ValidateEmployeNameSize(employeeName);
        }

        private void ValidateRemarkName(string remark)
        {
            if (remark == null)
            {
                InvalidRemarkValueFault fault = new InvalidRemarkValueFault
                {
                    FaultId = 205,
                    Message = "Remark can not be null"
                };

                throw new FaultException<InvalidRemarkValueFault>
                    (fault, "Remark can not be null");
            }
        }

        private void ValidateRemarkSize(string remark)
        {
            if (remark.Length == 0 || remark.Length > 30)
            {
                InvalidRemarkSizeFault fault = new InvalidRemarkSizeFault
                {
                    FaultId = 204,
                    Message = "Remark length out of range(1-10)"
                };
                throw new FaultException<InvalidRemarkSizeFault>
                    (fault, "Remark length out of range(1-10)");
            }
        }

        private void ValidateEmployeeId(int employeeId)
        {
            if (employeeId <= 0)
            {
                InvalidIdValueFault fault = new InvalidIdValueFault
                {
                    FaultId = 203,
                    Message = "Employee Id should be greater than 0"
                };
                throw new FaultException<InvalidIdValueFault>
                    (fault, "Employee Id should be greater than 0");
            }
        }


        private void ValidateEmptyEmployeeName(string employeeName)
        {
            if (employeeName == null)
            {
                InvalidNameValueFault fault = new InvalidNameValueFault
                {
                    FaultId = 202,
                    Message = "Employee Name can not be null"
                };

                throw new FaultException<InvalidNameValueFault>
                    (fault, "Employee Name can not be null");
            }


            if (!employeeRegex.IsMatch(employeeName))
            {
                InvalidNameValueFault fault = new InvalidNameValueFault
                {
                    FaultId = 202,
                    Message = "Employee Name can contain only letters"
                };
                throw new FaultException<InvalidNameValueFault>
                    (fault, "Employee Name can contain only letters");
            }
        }

        private static void ValidateEmployeNameSize(string employeeName)
        {
            if (employeeName.Length == 0 || employeeName.Length > 10)
            {
                InvalidNameSizeFault fault = new InvalidNameSizeFault
                {
                    FaultId = 201,
                    Message = "Employee Name length out of range(1-10)"
                };
                throw new FaultException<InvalidNameSizeFault>
                    (fault, "Employee Name length out of range(1-10)");
            }
        }
    }
}
