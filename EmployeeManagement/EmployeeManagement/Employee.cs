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
        public DateTime RemarkDate
        {
            get;
            set;
        }

        public string RemarkText
        {
            get;
            set;
        }
    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class Employee
    {
        [DataMember]
        public long Id
        {
            get;
            set;
        }

        [DataMember]
        public string Name
        {
            get;
            set;
        }

        [DataMember]
        public List<Remark> Remarks
        {
            get;
            set;
        }
    }
}