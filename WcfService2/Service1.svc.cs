using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;

namespace WcfService2
{
    public class Service1 : IService1
    {
        private static Dictionary<Guid, ToDoItem> _todos = new Dictionary<Guid, ToDoItem>();

        public List<ToDoItem> GetToDos()
        {
            return _todos.Values.ToList();
        }

        public void AddOrUpdateToDo(ToDoItem toDoItem)
        {
            _todos[toDoItem.Id] = toDoItem;
        }

        public bool ReplaceToDo(ToDoItem toDoItemToReplace, ToDoItem newToDo, bool throwFaultExceptionIfNotFound)
        {
            if (_todos.ContainsKey(toDoItemToReplace.Id))
            {
                _todos.Remove(toDoItemToReplace.Id);
                _todos[newToDo.Id] = newToDo;
                return true;
            }
            else
            {
                if (throwFaultExceptionIfNotFound)
                    throw new FaultException("ID not found: " + toDoItemToReplace.Id);

                return false;
            }
        }

        public void DeleteToDo(ToDoItem toDoItem)
        {
            if (_todos.ContainsKey(toDoItem.Id))
                _todos.Remove(toDoItem.Id);
            else
                throw new FaultException("ID not found: " + toDoItem.Id);
        }

        public void DeleteAllToDos()
        {
            _todos.Clear();
        }

        public int GetTheNumberOfToDos()
        {
            return _todos.Count;
        }

        public int? GetTheNumberOfToDosPlusX(int x)
        {
            return _todos.Count + x;
        }

        public DateTime GetServerDate()
        {
            return DateTime.Now;
        }

        public double MultiplyThreeNumbers(double x1, double x2, double x3)
        {
            return x1 * x2 * x3;
        }
    }
}