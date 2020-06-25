using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace WcfService2
{
    [ServiceContract]
    [XmlSerializerFormat]
    public interface IService1
    {
        [OperationContract]
        List<ToDoItem> GetToDos();

        [OperationContract]
        void AddOrUpdateToDo(ToDoItem toDoItem);

        [OperationContract]
        bool ReplaceToDo(ToDoItem toDoItemToReplace, ToDoItem newToDo, bool throwFaultExceptionIfNotFound);

        [OperationContract]
        void DeleteToDo(ToDoItem toDoItem);

        [OperationContract]
        void DeleteAllToDos();

        [OperationContract]
        int GetTheNumberOfToDos();

        [OperationContract]
        int? GetTheNumberOfToDosPlusX(int x);

        [OperationContract]
        DateTime GetServerDate();

        [OperationContract]
        double MultiplyThreeNumbers(double x1, double x2, double x3);
    }

    [DataContract]
    public class ToDoItem
    {
        [DataMember]
        public Guid Id { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public DateTime CreationDate { get; set; }

        [DataMember]
        public byte[] Bytes { get; set; }

        [DataMember]
        public int? NullableTest1 { get; set; }

        [DataMember]
        public int? NullableTest2 { get; set; }

        [DataMember]
        public DateTime? NullableTest3 { get; set; }

        [DataMember]
        public DateTime? NullableTest4 { get; set; }

        [DataMember]
        public char CharValue { get; set; }

        [DataMember]
        public ToDoImportance Importance { get; set; }

        [DataMember]
        public ObservableCollection<string> Tags { get; set; }
    }

    [DataContract]
    public enum ToDoImportance
    {
        [EnumMember]
        Low,
        [EnumMember]
        Mid,
        [EnumMember]
        High
    }
}