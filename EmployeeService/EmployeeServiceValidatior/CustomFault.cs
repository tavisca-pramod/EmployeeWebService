using System.Runtime.Serialization;

namespace EmployeeService
{
    [DataContract]
    public class InvalidNameSizeFault
    {
        [DataMember]
        public int FaultId { get; set; }
        [DataMember]
        public string Message { get; set; }
    }
    
    [DataContract]
    public class InvalidNameValueFault
    {
        [DataMember]
        public int FaultId { get; set; }
        [DataMember]
        public string Message { get; set; }
    }

    [DataContract]
    public class InvalidIdValueFault
    {
        [DataMember]
        public int FaultId { get; set; }
        [DataMember]
        public string Message { get; set; }
    }
    
    [DataContract]
    public class InvalidRemarkValueFault
    {
        [DataMember]
        public int FaultId { get; set; }
        [DataMember]
        public string Message { get; set; }
    }
    
    [DataContract]
    public class InvalidRemarkSizeFault
    {
        [DataMember]
        public int FaultId { get; set; }
        [DataMember]
        public string Message { get; set; }
    }
}