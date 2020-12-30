using System;
using System.Collections.Generic;
using System.Reflection;

namespace Moon.TodoList
{
    public class CommandParser
    {
        private string _method;
        private string _parameter;

        public CommandParser(string cmd)
        {
            var args = cmd.Trim().Split(' ');

            if (!args[0].ToLower().Equals("todo"))
            {
                throw new ArgumentException($"{args[0]} ：无法将{args[0]}识别的命令");
            }

            _method = args[1];
            _parameter = args[2];
        }

        public object Execute()
        {
            var type = typeof(Todo);
            var todo = Activator.CreateInstance(type);
            var method = type.GetMethod(_method, BindingFlags.Public | BindingFlags.NonPublic);
            return method?.Invoke(todo, new object[] {_parameter});
        }
    }
}