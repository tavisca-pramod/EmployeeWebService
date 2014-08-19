using System.Runtime.Serialization;

namespace EmployeeService
{
    [DataContract]
    public class InvalidNameSize
    {
        [DataMember]
        public int FaultId { get; set; }
        [DataMember]
        public string Message { get; set; }
    }
    
    [DataContract]
    public class InvalidNameValue
    {
        [DataMember]
        public int FaultId { get; set; }
        [DataMember]
        public string Message { get; set; }
    }

    [DataContract]
    public class InvalidIdValue
    {
        [DataMember]
        public int FaultId { get; set; }
        [DataMember]
        public string Message { get; set; }
    }
    
    [DataContract]
    public class InvalidRemarkValue
    {
        [DataMember]
        public int FaultId { get; set; }
        [DataMember]
        public string Message { get; set; }
    }
    
    [DataContract]
    public class InvalidRemarkSize
    {
        [DataMember]
        public int FaultId { get; set; }
        [DataMember]
        public string Message { get; set; }
    }
}