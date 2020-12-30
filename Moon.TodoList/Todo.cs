using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace Moon.TodoList
{
    public class Todo
    {
        private readonly string _filePath;
        private List<TodoItem> TodoItems { get; set; } = new List<TodoItem>();

        public Todo() : this(null)
        {
        }

        public Todo(string filePath)
        {
            _filePath = string.IsNullOrEmpty(filePath)
                ? Environment.CurrentDirectory + @"\" + "MoonTodoList.txt"
                : filePath;
            var records = File.ReadLines(_filePath);
            foreach (string record in records)
            {
                TodoItems.Add(new TodoItem(record));
            }
        }

        public void Add(string item)
        {
            File.WriteAllText(_filePath, item);
        }
    }

    public class TodoItem
    {
        public TodoItem(string record)
        {
            var args = record.Trim().Split(' ');
            Index = int.Parse(args[0]);
            Content = args[1];
            Complete = bool.Parse(args[2]);
        }

        public int Index { get; set; }

        public string Content { get; set; }

        public bool Complete { get; set; }
    }
}