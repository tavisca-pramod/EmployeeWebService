using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace EmployeeManagement
{
    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class Remark
    {
        [DataMember]
        public DateTime RemarkDate { get; set; }

        [DataMember]
        public string RemarkText { get; set; }

        public override bool Equals(Object remark)
        {
            if (remark == null)
            {
                return false;
            }

            Remark p = remark as Remark;
            if ((System.Object)p == null)
            {
                return false;
            }

            return (this.RemarkDate.Equals(p.RemarkDate));
        }
        public override int GetHashCode()
        {
            return this.RemarkDate.GetHashCode();
        }
    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class Employee
    {
        [DataMember]
        public long Id { get; set; }

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
        public override int GetHashCode() {
            return Int32.Parse(this.Id.ToString());
        }
    }
}