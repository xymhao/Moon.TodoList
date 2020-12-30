using System;
using System.Collections.Generic;
using System.IO;

namespace Moon.TodoList
{
    public class TextPersistence : ITodoPersistence
    {
        private readonly string _filePath;

        public TextPersistence()
        {
            _filePath = Environment.CurrentDirectory + @"\" + "MoonTodoList.txt";
        }

        public TextPersistence(string path)
        {
            _filePath = path;
        }

        public void Save(IEnumerable<string> records)
        {
            File.WriteAllLines(_filePath, records);
        }

        public IEnumerable<string> Read()
        {
            return File.ReadAllLines(_filePath);
        }
    }
}