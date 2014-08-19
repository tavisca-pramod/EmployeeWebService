﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18063
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EmployeeFixtures.EmployeeServiceReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Employee", Namespace="http://schemas.datacontract.org/2004/07/EmployeeService")]
    [System.SerializableAttribute()]
    public partial class Employee : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Collections.Generic.List<EmployeeFixtures.EmployeeServiceReference.Remark> RemarksField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Name {
            get {
                return this.NameField;
            }
            set {
                if ((object.ReferenceEquals(this.NameField, value) != true)) {
                    this.NameField = value;
                    this.RaisePropertyChanged("Name");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Collections.Generic.List<EmployeeFixtures.EmployeeServiceReference.Remark> Remarks {
            get {
                return this.RemarksField;
            }
            set {
                if ((object.ReferenceEquals(this.RemarksField, value) != true)) {
                    this.RemarksField = value;
                    this.RaisePropertyChanged("Remarks");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Remark", Namespace="http://schemas.datacontract.org/2004/07/EmployeeService")]
    [System.SerializableAttribute()]
    public partial class Remark : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime RemarkDateField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string RemarkTextField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime RemarkDate {
            get {
                return this.RemarkDateField;
            }
            set {
                if ((this.RemarkDateField.Equals(value) != true)) {
                    this.RemarkDateField = value;
                    this.RaisePropertyChanged("RemarkDate");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string RemarkText {
            get {
                return this.RemarkTextField;
            }
            set {
                if ((object.ReferenceEquals(this.RemarkTextField, value) != true)) {
                    this.RemarkTextField = value;
                    this.RaisePropertyChanged("RemarkText");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="EmployeeAlreadyExistsFault", Namespace="http://schemas.datacontract.org/2004/07/EmployeeService")]
    [System.SerializableAttribute()]
    public partial class EmployeeAlreadyExistsFault : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int FaultIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string MessageField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int FaultId {
            get {
                return this.FaultIdField;
            }
            set {
                if ((this.FaultIdField.Equals(value) != true)) {
                    this.FaultIdField = value;
                    this.RaisePropertyChanged("FaultId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Message {
            get {
                return this.MessageField;
            }
            set {
                if ((object.ReferenceEquals(this.MessageField, value) != true)) {
                    this.MessageField = value;
                    this.RaisePropertyChanged("Message");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ResultNotFoundFault", Namespace="http://schemas.datacontract.org/2004/07/EmployeeService")]
    [System.SerializableAttribute()]
    public partial class ResultNotFoundFault : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int FaultIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string MessageField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int FaultId {
            get {
                return this.FaultIdField;
            }
            set {
                if ((this.FaultIdField.Equals(value) != true)) {
                    this.FaultIdField = value;
                    this.RaisePropertyChanged("FaultId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Message {
            get {
                return this.MessageField;
            }
            set {
                if ((object.ReferenceEquals(this.MessageField, value) != true)) {
                    this.MessageField = value;
                    this.RaisePropertyChanged("Message");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="EmployeeServiceReference.IEmployeeManager")]
    public interface IEmployeeManager {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEmployeeManager/CreateEmployee", ReplyAction="http://tempuri.org/IEmployeeManager/CreateEmployeeResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(EmployeeFixtures.EmployeeServiceReference.EmployeeAlreadyExistsFault), Action="http://tempuri.org/IEmployeeManager/CreateEmployeeEmployeeAlreadyExistsFaultFault" +
            "", Name="EmployeeAlreadyExistsFault", Namespace="http://schemas.datacontract.org/2004/07/EmployeeService")]
        EmployeeFixtures.EmployeeServiceReference.Employee CreateEmployee(int id, string name, string remarks);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEmployeeManager/CreateEmployee", ReplyAction="http://tempuri.org/IEmployeeManager/CreateEmployeeResponse")]
        System.Threading.Tasks.Task<EmployeeFixtures.EmployeeServiceReference.Employee> CreateEmployeeAsync(int id, string name, string remarks);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEmployeeManager/AddRemark", ReplyAction="http://tempuri.org/IEmployeeManager/AddRemarkResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(EmployeeFixtures.EmployeeServiceReference.ResultNotFoundFault), Action="http://tempuri.org/IEmployeeManager/AddRemarkResultNotFoundFaultFault", Name="ResultNotFoundFault", Namespace="http://schemas.datacontract.org/2004/07/EmployeeService")]
        void AddRemark(int id, string remarks);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEmployeeManager/AddRemark", ReplyAction="http://tempuri.org/IEmployeeManager/AddRemarkResponse")]
        System.Threading.Tasks.Task AddRemarkAsync(int id, string remarks);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEmployeeManager/DeleteEmployeeById", ReplyAction="http://tempuri.org/IEmployeeManager/DeleteEmployeeByIdResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(EmployeeFixtures.EmployeeServiceReference.ResultNotFoundFault), Action="http://tempuri.org/IEmployeeManager/DeleteEmployeeByIdResultNotFoundFaultFault", Name="ResultNotFoundFault", Namespace="http://schemas.datacontract.org/2004/07/EmployeeService")]
        void DeleteEmployeeById(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEmployeeManager/DeleteEmployeeById", ReplyAction="http://tempuri.org/IEmployeeManager/DeleteEmployeeByIdResponse")]
        System.Threading.Tasks.Task DeleteEmployeeByIdAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEmployeeManager/DeleteEmployees", ReplyAction="http://tempuri.org/IEmployeeManager/DeleteEmployeesResponse")]
        void DeleteEmployees();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEmployeeManager/DeleteEmployees", ReplyAction="http://tempuri.org/IEmployeeManager/DeleteEmployeesResponse")]
        System.Threading.Tasks.Task DeleteEmployeesAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IEmployeeManagerChannel : EmployeeFixtures.EmployeeServiceReference.IEmployeeManager, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class EmployeeManagerClient : System.ServiceModel.ClientBase<EmployeeFixtures.EmployeeServiceReference.IEmployeeManager>, EmployeeFixtures.EmployeeServiceReference.IEmployeeManager {
        
        public EmployeeManagerClient() {
        }
        
        public EmployeeManagerClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public EmployeeManagerClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public EmployeeManagerClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public EmployeeManagerClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public EmployeeFixtures.EmployeeServiceReference.Employee CreateEmployee(int id, string name, string remarks) {
            return base.Channel.CreateEmployee(id, name, remarks);
        }
        
        public System.Threading.Tasks.Task<EmployeeFixtures.EmployeeServiceReference.Employee> CreateEmployeeAsync(int id, string name, string remarks) {
            return base.Channel.CreateEmployeeAsync(id, name, remarks);
        }
        
        public void AddRemark(int id, string remarks) {
            base.Channel.AddRemark(id, remarks);
        }
        
        public System.Threading.Tasks.Task AddRemarkAsync(int id, string remarks) {
            return base.Channel.AddRemarkAsync(id, remarks);
        }
        
        public void DeleteEmployeeById(int id) {
            base.Channel.DeleteEmployeeById(id);
        }
        
        public System.Threading.Tasks.Task DeleteEmployeeByIdAsync(int id) {
            return base.Channel.DeleteEmployeeByIdAsync(id);
        }
        
        public void DeleteEmployees() {
            base.Channel.DeleteEmployees();
        }
        
        public System.Threading.Tasks.Task DeleteEmployeesAsync() {
            return base.Channel.DeleteEmployeesAsync();
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="EmployeeServiceReference.IEmployeeReader")]
    public interface IEmployeeReader {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEmployeeReader/GetEmployeeDetailsById", ReplyAction="http://tempuri.org/IEmployeeReader/GetEmployeeDetailsByIdResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(System.ServiceModel.FaultException), Action="http://tempuri.org/IEmployeeReader/GetEmployeeDetailsByIdFaultExceptionFault", Name="FaultException", Namespace="http://schemas.datacontract.org/2004/07/System.ServiceModel")]
        EmployeeFixtures.EmployeeServiceReference.Employee GetEmployeeDetailsById(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEmployeeReader/GetEmployeeDetailsById", ReplyAction="http://tempuri.org/IEmployeeReader/GetEmployeeDetailsByIdResponse")]
        System.Threading.Tasks.Task<EmployeeFixtures.EmployeeServiceReference.Employee> GetEmployeeDetailsByIdAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEmployeeReader/GetAllEmployees", ReplyAction="http://tempuri.org/IEmployeeReader/GetAllEmployeesResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(EmployeeFixtures.EmployeeServiceReference.ResultNotFoundFault), Action="http://tempuri.org/IEmployeeReader/GetAllEmployeesResultNotFoundFaultFault", Name="ResultNotFoundFault", Namespace="http://schemas.datacontract.org/2004/07/EmployeeService")]
        System.Collections.Generic.List<EmployeeFixtures.EmployeeServiceReference.Employee> GetAllEmployees();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEmployeeReader/GetAllEmployees", ReplyAction="http://tempuri.org/IEmployeeReader/GetAllEmployeesResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<EmployeeFixtures.EmployeeServiceReference.Employee>> GetAllEmployeesAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEmployeeReader/GetEmployeesByName", ReplyAction="http://tempuri.org/IEmployeeReader/GetEmployeesByNameResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(EmployeeFixtures.EmployeeServiceReference.ResultNotFoundFault), Action="http://tempuri.org/IEmployeeReader/GetEmployeesByNameResultNotFoundFaultFault", Name="ResultNotFoundFault", Namespace="http://schemas.datacontract.org/2004/07/EmployeeService")]
        System.Collections.Generic.List<EmployeeFixtures.EmployeeServiceReference.Employee> GetEmployeesByName(string name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEmployeeReader/GetEmployeesByName", ReplyAction="http://tempuri.org/IEmployeeReader/GetEmployeesByNameResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<EmployeeFixtures.EmployeeServiceReference.Employee>> GetEmployeesByNameAsync(string name);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IEmployeeReaderChannel : EmployeeFixtures.EmployeeServiceReference.IEmployeeReader, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class EmployeeReaderClient : System.ServiceModel.ClientBase<EmployeeFixtures.EmployeeServiceReference.IEmployeeReader>, EmployeeFixtures.EmployeeServiceReference.IEmployeeReader {
        
        public EmployeeReaderClient() {
        }
        
        public EmployeeReaderClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public EmployeeReaderClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public EmployeeReaderClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public EmployeeReaderClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public EmployeeFixtures.EmployeeServiceReference.Employee GetEmployeeDetailsById(int id) {
            return base.Channel.GetEmployeeDetailsById(id);
        }
        
        public System.Threading.Tasks.Task<EmployeeFixtures.EmployeeServiceReference.Employee> GetEmployeeDetailsByIdAsync(int id) {
            return base.Channel.GetEmployeeDetailsByIdAsync(id);
        }
        
        public System.Collections.Generic.List<EmployeeFixtures.EmployeeServiceReference.Employee> GetAllEmployees() {
            return base.Channel.GetAllEmployees();
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<EmployeeFixtures.EmployeeServiceReference.Employee>> GetAllEmployeesAsync() {
            return base.Channel.GetAllEmployeesAsync();
        }
        
        public System.Collections.Generic.List<EmployeeFixtures.EmployeeServiceReference.Employee> GetEmployeesByName(string name) {
            return base.Channel.GetEmployeesByName(name);
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<EmployeeFixtures.EmployeeServiceReference.Employee>> GetEmployeesByNameAsync(string name) {
            return base.Channel.GetEmployeesByNameAsync(name);
        }
    }
}