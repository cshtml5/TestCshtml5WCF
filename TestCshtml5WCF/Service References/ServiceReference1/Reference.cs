﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TestCshtml5WCF.ServiceReference1 {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ToDoItem", Namespace="http://schemas.datacontract.org/2004/07/WcfService1")]
    [System.SerializableAttribute()]
    public partial class ToDoItem : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private byte[] BytesField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private char CharValueField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime CreationDateField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DescriptionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Guid IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private TestCshtml5WCF.ServiceReference1.ToDoImportance ImportanceField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<int> NullableTest1Field;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<int> NullableTest2Field;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<System.DateTime> NullableTest3Field;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<System.DateTime> NullableTest4Field;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string[] TagsField;
        
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
        public byte[] Bytes {
            get {
                return this.BytesField;
            }
            set {
                if ((object.ReferenceEquals(this.BytesField, value) != true)) {
                    this.BytesField = value;
                    this.RaisePropertyChanged("Bytes");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public char CharValue {
            get {
                return this.CharValueField;
            }
            set {
                if ((this.CharValueField.Equals(value) != true)) {
                    this.CharValueField = value;
                    this.RaisePropertyChanged("CharValue");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime CreationDate {
            get {
                return this.CreationDateField;
            }
            set {
                if ((this.CreationDateField.Equals(value) != true)) {
                    this.CreationDateField = value;
                    this.RaisePropertyChanged("CreationDate");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Description {
            get {
                return this.DescriptionField;
            }
            set {
                if ((object.ReferenceEquals(this.DescriptionField, value) != true)) {
                    this.DescriptionField = value;
                    this.RaisePropertyChanged("Description");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Guid Id {
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
        public TestCshtml5WCF.ServiceReference1.ToDoImportance Importance {
            get {
                return this.ImportanceField;
            }
            set {
                if ((this.ImportanceField.Equals(value) != true)) {
                    this.ImportanceField = value;
                    this.RaisePropertyChanged("Importance");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<int> NullableTest1 {
            get {
                return this.NullableTest1Field;
            }
            set {
                if ((this.NullableTest1Field.Equals(value) != true)) {
                    this.NullableTest1Field = value;
                    this.RaisePropertyChanged("NullableTest1");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<int> NullableTest2 {
            get {
                return this.NullableTest2Field;
            }
            set {
                if ((this.NullableTest2Field.Equals(value) != true)) {
                    this.NullableTest2Field = value;
                    this.RaisePropertyChanged("NullableTest2");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<System.DateTime> NullableTest3 {
            get {
                return this.NullableTest3Field;
            }
            set {
                if ((this.NullableTest3Field.Equals(value) != true)) {
                    this.NullableTest3Field = value;
                    this.RaisePropertyChanged("NullableTest3");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<System.DateTime> NullableTest4 {
            get {
                return this.NullableTest4Field;
            }
            set {
                if ((this.NullableTest4Field.Equals(value) != true)) {
                    this.NullableTest4Field = value;
                    this.RaisePropertyChanged("NullableTest4");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string[] Tags {
            get {
                return this.TagsField;
            }
            set {
                if ((object.ReferenceEquals(this.TagsField, value) != true)) {
                    this.TagsField = value;
                    this.RaisePropertyChanged("Tags");
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
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ToDoImportance", Namespace="http://schemas.datacontract.org/2004/07/WcfService1")]
    public enum ToDoImportance : int {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Low = 0,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Mid = 1,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        High = 2,
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.IService1")]
    public interface IService1 {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetToDos", ReplyAction="http://tempuri.org/IService1/GetToDosResponse")]
        TestCshtml5WCF.ServiceReference1.ToDoItem[] GetToDos();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetToDos", ReplyAction="http://tempuri.org/IService1/GetToDosResponse")]
        System.Threading.Tasks.Task<TestCshtml5WCF.ServiceReference1.ToDoItem[]> GetToDosAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/AddOrUpdateToDo", ReplyAction="http://tempuri.org/IService1/AddOrUpdateToDoResponse")]
        void AddOrUpdateToDo(TestCshtml5WCF.ServiceReference1.ToDoItem toDoItem);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/AddOrUpdateToDo", ReplyAction="http://tempuri.org/IService1/AddOrUpdateToDoResponse")]
        System.Threading.Tasks.Task AddOrUpdateToDoAsync(TestCshtml5WCF.ServiceReference1.ToDoItem toDoItem);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/ReplaceToDo", ReplyAction="http://tempuri.org/IService1/ReplaceToDoResponse")]
        bool ReplaceToDo(TestCshtml5WCF.ServiceReference1.ToDoItem toDoItemToReplace, TestCshtml5WCF.ServiceReference1.ToDoItem newToDo, bool throwFaultExceptionIfNotFound);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/ReplaceToDo", ReplyAction="http://tempuri.org/IService1/ReplaceToDoResponse")]
        System.Threading.Tasks.Task<bool> ReplaceToDoAsync(TestCshtml5WCF.ServiceReference1.ToDoItem toDoItemToReplace, TestCshtml5WCF.ServiceReference1.ToDoItem newToDo, bool throwFaultExceptionIfNotFound);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/DeleteToDo", ReplyAction="http://tempuri.org/IService1/DeleteToDoResponse")]
        void DeleteToDo(TestCshtml5WCF.ServiceReference1.ToDoItem toDoItem);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/DeleteToDo", ReplyAction="http://tempuri.org/IService1/DeleteToDoResponse")]
        System.Threading.Tasks.Task DeleteToDoAsync(TestCshtml5WCF.ServiceReference1.ToDoItem toDoItem);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/DeleteAllToDos", ReplyAction="http://tempuri.org/IService1/DeleteAllToDosResponse")]
        void DeleteAllToDos();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/DeleteAllToDos", ReplyAction="http://tempuri.org/IService1/DeleteAllToDosResponse")]
        System.Threading.Tasks.Task DeleteAllToDosAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetTheNumberOfToDos", ReplyAction="http://tempuri.org/IService1/GetTheNumberOfToDosResponse")]
        int GetTheNumberOfToDos();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetTheNumberOfToDos", ReplyAction="http://tempuri.org/IService1/GetTheNumberOfToDosResponse")]
        System.Threading.Tasks.Task<int> GetTheNumberOfToDosAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetTheNumberOfToDosPlusX", ReplyAction="http://tempuri.org/IService1/GetTheNumberOfToDosPlusXResponse")]
        System.Nullable<int> GetTheNumberOfToDosPlusX(int x);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetTheNumberOfToDosPlusX", ReplyAction="http://tempuri.org/IService1/GetTheNumberOfToDosPlusXResponse")]
        System.Threading.Tasks.Task<System.Nullable<int>> GetTheNumberOfToDosPlusXAsync(int x);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetServerDate", ReplyAction="http://tempuri.org/IService1/GetServerDateResponse")]
        System.DateTime GetServerDate();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetServerDate", ReplyAction="http://tempuri.org/IService1/GetServerDateResponse")]
        System.Threading.Tasks.Task<System.DateTime> GetServerDateAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/MultiplyThreeNumbers", ReplyAction="http://tempuri.org/IService1/MultiplyThreeNumbersResponse")]
        double MultiplyThreeNumbers(double x1, double x2, double x3);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/MultiplyThreeNumbers", ReplyAction="http://tempuri.org/IService1/MultiplyThreeNumbersResponse")]
        System.Threading.Tasks.Task<double> MultiplyThreeNumbersAsync(double x1, double x2, double x3);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/RoundTripTest", ReplyAction="http://tempuri.org/IService1/RoundTripTestResponse")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(TestCshtml5WCF.ServiceReference1.ToDoItem))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(TestCshtml5WCF.ServiceReference1.ToDoImportance))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(TestCshtml5WCF.ServiceReference1.ToDoItem[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(string[]))]
        object RoundTripTest(object obj);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/RoundTripTest", ReplyAction="http://tempuri.org/IService1/RoundTripTestResponse")]
        System.Threading.Tasks.Task<object> RoundTripTestAsync(object obj);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/RoundTripTest2", ReplyAction="http://tempuri.org/IService1/RoundTripTest2Response")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(TestCshtml5WCF.ServiceReference1.ToDoItem))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(TestCshtml5WCF.ServiceReference1.ToDoImportance))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(TestCshtml5WCF.ServiceReference1.ToDoItem[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(string[]))]
        object RoundTripTest2(object obj);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/RoundTripTest2", ReplyAction="http://tempuri.org/IService1/RoundTripTest2Response")]
        System.Threading.Tasks.Task<object> RoundTripTest2Async(object obj);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/ReceiveFaultException", ReplyAction="http://tempuri.org/IService1/ReceiveFaultExceptionResponse")]
        void ReceiveFaultException();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/ReceiveFaultException", ReplyAction="http://tempuri.org/IService1/ReceiveFaultExceptionResponse")]
        System.Threading.Tasks.Task ReceiveFaultExceptionAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/ReceiveServerInternalErrorException", ReplyAction="http://tempuri.org/IService1/ReceiveServerInternalErrorExceptionResponse")]
        void ReceiveServerInternalErrorException();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/ReceiveServerInternalErrorException", ReplyAction="http://tempuri.org/IService1/ReceiveServerInternalErrorExceptionResponse")]
        System.Threading.Tasks.Task ReceiveServerInternalErrorExceptionAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IService1Channel : TestCshtml5WCF.ServiceReference1.IService1, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class Service1Client : System.ServiceModel.ClientBase<TestCshtml5WCF.ServiceReference1.IService1>, TestCshtml5WCF.ServiceReference1.IService1 {
        
        public Service1Client() {
        }
        
        public Service1Client(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public Service1Client(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public TestCshtml5WCF.ServiceReference1.ToDoItem[] GetToDos() {
            return base.Channel.GetToDos();
        }
        
        public System.Threading.Tasks.Task<TestCshtml5WCF.ServiceReference1.ToDoItem[]> GetToDosAsync() {
            return base.Channel.GetToDosAsync();
        }
        
        public void AddOrUpdateToDo(TestCshtml5WCF.ServiceReference1.ToDoItem toDoItem) {
            base.Channel.AddOrUpdateToDo(toDoItem);
        }
        
        public System.Threading.Tasks.Task AddOrUpdateToDoAsync(TestCshtml5WCF.ServiceReference1.ToDoItem toDoItem) {
            return base.Channel.AddOrUpdateToDoAsync(toDoItem);
        }
        
        public bool ReplaceToDo(TestCshtml5WCF.ServiceReference1.ToDoItem toDoItemToReplace, TestCshtml5WCF.ServiceReference1.ToDoItem newToDo, bool throwFaultExceptionIfNotFound) {
            return base.Channel.ReplaceToDo(toDoItemToReplace, newToDo, throwFaultExceptionIfNotFound);
        }
        
        public System.Threading.Tasks.Task<bool> ReplaceToDoAsync(TestCshtml5WCF.ServiceReference1.ToDoItem toDoItemToReplace, TestCshtml5WCF.ServiceReference1.ToDoItem newToDo, bool throwFaultExceptionIfNotFound) {
            return base.Channel.ReplaceToDoAsync(toDoItemToReplace, newToDo, throwFaultExceptionIfNotFound);
        }
        
        public void DeleteToDo(TestCshtml5WCF.ServiceReference1.ToDoItem toDoItem) {
            base.Channel.DeleteToDo(toDoItem);
        }
        
        public System.Threading.Tasks.Task DeleteToDoAsync(TestCshtml5WCF.ServiceReference1.ToDoItem toDoItem) {
            return base.Channel.DeleteToDoAsync(toDoItem);
        }
        
        public void DeleteAllToDos() {
            base.Channel.DeleteAllToDos();
        }
        
        public System.Threading.Tasks.Task DeleteAllToDosAsync() {
            return base.Channel.DeleteAllToDosAsync();
        }
        
        public int GetTheNumberOfToDos() {
            return base.Channel.GetTheNumberOfToDos();
        }
        
        public System.Threading.Tasks.Task<int> GetTheNumberOfToDosAsync() {
            return base.Channel.GetTheNumberOfToDosAsync();
        }
        
        public System.Nullable<int> GetTheNumberOfToDosPlusX(int x) {
            return base.Channel.GetTheNumberOfToDosPlusX(x);
        }
        
        public System.Threading.Tasks.Task<System.Nullable<int>> GetTheNumberOfToDosPlusXAsync(int x) {
            return base.Channel.GetTheNumberOfToDosPlusXAsync(x);
        }
        
        public System.DateTime GetServerDate() {
            return base.Channel.GetServerDate();
        }
        
        public System.Threading.Tasks.Task<System.DateTime> GetServerDateAsync() {
            return base.Channel.GetServerDateAsync();
        }
        
        public double MultiplyThreeNumbers(double x1, double x2, double x3) {
            return base.Channel.MultiplyThreeNumbers(x1, x2, x3);
        }
        
        public System.Threading.Tasks.Task<double> MultiplyThreeNumbersAsync(double x1, double x2, double x3) {
            return base.Channel.MultiplyThreeNumbersAsync(x1, x2, x3);
        }
        
        public object RoundTripTest(object obj) {
            return base.Channel.RoundTripTest(obj);
        }
        
        public System.Threading.Tasks.Task<object> RoundTripTestAsync(object obj) {
            return base.Channel.RoundTripTestAsync(obj);
        }
        
        public object RoundTripTest2(object obj) {
            return base.Channel.RoundTripTest2(obj);
        }
        
        public System.Threading.Tasks.Task<object> RoundTripTest2Async(object obj) {
            return base.Channel.RoundTripTest2Async(obj);
        }
        
        public void ReceiveFaultException() {
            base.Channel.ReceiveFaultException();
        }
        
        public System.Threading.Tasks.Task ReceiveFaultExceptionAsync() {
            return base.Channel.ReceiveFaultExceptionAsync();
        }
        
        public void ReceiveServerInternalErrorException() {
            base.Channel.ReceiveServerInternalErrorException();
        }
        
        public System.Threading.Tasks.Task ReceiveServerInternalErrorExceptionAsync() {
            return base.Channel.ReceiveServerInternalErrorExceptionAsync();
        }
    }
}
