using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;

namespace EmployeeManagement
{  // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IEmployeeWriter
    {
        [OperationContract]
        void CreateEmployee(Employee employee, Remark remark);

        [OperationContract]
        void AddRemarksToEmplyee(long employeeId, Remark remark);
    }
}