using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;

namespace Moon.TodoList
{
    public class Todo
    {
        public ITodoPersistence Persistence { get; set; }  = new TextPersistence();

        public List<TodoItem> TodoItems { get; set; } = new List<TodoItem>();

        public Todo()
        {
            var records = Persistence.Read();
            foreach (string record in records)
            {
                TodoItems.Add(new TodoItem(record));
            }
        }

        public string Add(string item)
        {
            var todoItem = new TodoItem(TodoItems.Count, item);
            TodoItems.Add(todoItem);
            Save();
            return $"Item {TodoItems.Count} added";
        }

        private void Save()
        {
            var records = TodoItems.Select(x => x.ToString());
            Persistence.Save(records);
        }
    }
}