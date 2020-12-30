using System;

namespace Moon.TodoList
{
    public class TodoException : Exception
    {
        public TodoException(string message) : base(message)
        {
        }
    }
}