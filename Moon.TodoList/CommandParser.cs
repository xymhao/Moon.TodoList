using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Moon.TodoList
{
    public class CommandParser
    {
        private readonly string _method;
        private readonly string _parameter;

        public CommandParser(string cmd)
        {
            var args = cmd.Trim().Split(' ');

            if (!args[0].ToLower().Equals("todo"))
            {
                throw new ArgumentException($"{args[0]} ：无法将{args[0]}识别的命令");
            }

            _method = args[1];
            if (args.Length > 2)
            {
                var parameters = string.Empty;
                for (int i = 2; i < args.Length; i++)
                {
                    parameters += args[i] + " ";
                }

                _parameter = parameters;
            }
            else
            {
                _parameter = null;
            }
        }

        /// <summary>
        /// 根据命令执行对应方法
        /// </summary>
        /// <returns></returns>
        /// <exception cref="TodoException"></exception>
        public object Execute()
        {
            var type = typeof(Todo);
            var todo = Activator.CreateInstance(type);
            var methods = type.GetMethods();
            var method = methods.First(x =>
                string.Equals(x.Name, _method, StringComparison.CurrentCultureIgnoreCase));
            if (method == null)
            {
                throw new TodoException($"{_method} 命令不识别");
            }

            return method.Invoke(todo, new object[] {_parameter});
        }

        public string GetParserMethod()
        {
            return _method;
        }
    }
}