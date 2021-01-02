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
        public ITodoPersistence Persistence { get; }  = new TextPersistence();

        public List<TodoItem> TodoItems { get; } = new List<TodoItem>();

        public Todo()
        {
            TodoItems = Persistence.Read().ToList();
        }

        public Todo(string path)
        {
            Persistence = new TextPersistence(path);
        }
        
        public string Add(string item)
        {
            var todoItem = new TodoItem(TodoItems.Count +1, item);
            TodoItems.Add(todoItem);
            Save();
            Show(TodoItems);
            return $"Item {todoItem.Index} added";
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

        /// <summary>
        /// 获取todolist列表
        /// 缺省情况默认返回未完成的
        /// </summary>
        /// <param name="type"></param>
        public string List(string type)
        {
            var unCompleteItems = TodoItems.Where(x=>!x.Complete).ToList();

            if (string.IsNullOrEmpty(type))
            {
                Show(unCompleteItems);
                return $"Total: {unCompleteItems.Count()} items";
            }
            
            return type == "--all" ? 
                $"Total: {TodoItems.Count} items, {TodoItems.Count -unCompleteItems.Count()} item done"
                : throw  new TodoException($"{type} 为无法识别的命令");
        }

        private void Show(IEnumerable<TodoItem> list)
        {
            foreach (TodoItem todoItem in list)
            {
                Console.WriteLine($"{todoItem.Index}. {todoItem.Content} ");
            }
        }
    }
}