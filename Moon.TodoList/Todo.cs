using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mime;

namespace Moon.TodoList
{
    public class Todo
    {
        public ITodoPersistence Persistence { get; set; }  = new TextPersistence();

        public List<TodoItem> TodoItems { get; }

        public Todo()
        {
            TodoItems = Persistence.Read().ToList();
        }

        public TodoItem Add(string item)
        {
            var todoItem = new TodoItem(TodoItems.Count +1, item);
            TodoItems.Add(todoItem);
            Save();
            return todoItem;
        }

        private void Save()
        {
            Persistence.Save(TodoItems);
        }

        public string Done(int index)
        {
            var targetItem = TodoItems.Find(x => x.Index == index);
            if (targetItem == null)
            {
                throw  new TodoException("index 不存在");
            }

            targetItem.Done();

            Save();
            
            return $"Item {index} done.";
        }
    }
}