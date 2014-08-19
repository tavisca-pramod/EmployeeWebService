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

            return null;
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

                    ValidateRemarkName(remark);
                    ValidateRemarkSize(remark);
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

                    ValidateEmployeName(employeeName);
                    ValidateEmployeNameSize(employeeName);
                }

                if (index == 2)
                {
                    string remark = (String)inputs[index];

                    ValidateRemarkName(remark);
                    ValidateRemarkSize(remark);
                }
            }
        }

        private void ValidateRemarkName(string remark)
        {
            if (remark == null)
            {
                InvalidRemarkValue fault = new InvalidRemarkValue
                {
                    FaultId = 205,
                    Message = "Remark can not be null"
                };

                throw new FaultException<InvalidRemarkValue>
                    (fault, "Remark can not be null");
            }
        }

        private void ValidateRemarkSize(string remark)
        {
            if (remark.Length == 0 || remark.Length > 30)
            {
                InvalidRemarkSize fault = new InvalidRemarkSize
                {
                    FaultId = 204,
                    Message = "Remark length out of range(1-10)"
                };
                throw new FaultException<InvalidRemarkSize>
                    (fault, "Remark length out of range(1-10)");
            }
        }

        private void ValidateEmployeeId(int employeeId)
        {
            if (employeeId <= 0)
            {
                InvalidIdValue fault = new InvalidIdValue
                {
                    FaultId = 203,
                    Message = "Employee Id should be greater than 0"
                };
                throw new FaultException<InvalidIdValue>
                    (fault, "Employee Id should be greater than 0");
            }
        }


        private void ValidateEmployeName(string employeeName)
        {
            if (employeeName == null)
            {
                InvalidNameValue fault = new InvalidNameValue
                {
                    FaultId = 202,
                    Message = "Employee Name can not be null"
                };

                throw new FaultException<InvalidNameValue>
                    (fault, "Employee Name can not be null");
            }


            if (!employeeRegex.IsMatch(employeeName))
            {
                InvalidNameValue fault = new InvalidNameValue
                {
                    FaultId = 202,
                    Message = "Employee Name can contain only letters"
                };
                throw new FaultException<InvalidNameValue>
                    (fault, "Employee Name can contain only letters");
            }
        }

        private static void ValidateEmployeNameSize(string employeeName)
        {
            if (employeeName.Length == 0 || employeeName.Length > 10)
            {
                InvalidNameSize fault = new InvalidNameSize
                {
                    FaultId = 201,
                    Message = "Employee Name length out of range(1-10)"
                };
                throw new FaultException<InvalidNameSize>
                    (fault, "Employee Name length out of range(1-10)");
            }
        }
    }
}
