using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

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
            File.WriteAllText(_filePath, JsonConvert.SerializeObject(records));
        }

        public IEnumerable<TodoItem> Read()
        {
            var texts= File.ReadAllText(_filePath);
            return  JsonConvert.DeserializeObject<List<TodoItem>>(texts);
        }
    }
}