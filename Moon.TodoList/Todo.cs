using System;
using System.IO;
using System.Net;

namespace Moon.TodoList
{
    public class Todo
    {
        private readonly string _filePath;

        public Todo(string filePath)
        {
            _filePath = string.IsNullOrEmpty(filePath)
                ? Environment.CurrentDirectory + @"\" + "MoonTodoList.txt"
                : filePath;
        }
        
        public void Add(string item)
        {
            File.WriteAllText(_filePath,item);
        }
    }
}