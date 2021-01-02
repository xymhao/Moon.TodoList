using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Moon.TodoList
{
    public class TextPersistence : ITodoPersistence
    {
        private readonly string _filePath;

        public TextPersistence():this(Environment.CurrentDirectory + @"\" + "MoonTodoList.txt")
        {
        }

        public TextPersistence(string path)
        {
            _filePath = path;
            InitTextFile();
        }

        private void InitTextFile()
        {
            if (!File.Exists(_filePath))
            {
                var file = File.Create(_filePath);
                file.Close();
            }
        }

        public void Save(IEnumerable<TodoItem> records)
        {
            File.WriteAllLines(_filePath, records.Select(x=>x.ToSaveString()));
        }

        public IEnumerable<TodoItem> Read()
        {
            var texts= File.ReadAllLines(_filePath);
            return texts.Select(text => new TodoItem(text)).ToList();
        }
    }
}