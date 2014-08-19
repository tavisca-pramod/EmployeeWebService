﻿using System.Runtime.Serialization;

namespace EmployeeService
{
    [DataContract]
    public class EmployeeAlreadyExistsFault
    {
        [DataMember]
        public int FaultId { get; set; }
        [DataMember]
        public string Message { get; set; }
    }

    [DataContract]
    public class ResultNotFoundFault
    {
        [DataMember]
        public int FaultId { get; set; }
        [DataMember]
        public string Message { get; set; }
    }
}