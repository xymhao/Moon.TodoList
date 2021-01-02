using System;

namespace Moon.TodoList
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to moon TodoList");
            var cmd = Console.ReadLine();

            while (cmd != "exit")
            {
                var parser = new CommandParser(cmd);
                var output =parser.Execute();
                Console.WriteLine(output.ToString());
                cmd = Console.ReadLine();
            }
        }
    }
}