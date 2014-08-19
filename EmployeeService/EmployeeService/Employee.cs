using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace EmployeeService
{
    [DataContract]
    public class Employee
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public List<Remark> Remarks { get; set; }

        public override bool Equals(Object employee)
        {
            if (employee == null)
            {
                return false;
            }

            Employee p = employee as Employee;
            if ((System.Object)p == null)
            {
                return false;
            }

            return (this.Id == p.Id);
        }
        public override int GetHashCode()
        {
            return Int32.Parse(this.Id.ToString());
        }
    }

    public class Remark
    {
        [DataMember]
        public DateTime RemarkDate { get; set; }

        [DataMember]
        public string RemarkText { get; set; }
    }
}