using System;
using System.Collections.Generic;
using System.IO;
using Xunit;

namespace Moon.TodoList.Tests
{
    public class TextPersistenceTests
    {
        [Fact]
        public void Should_Save_Read_Success()
        {
            var filePath = Environment.CurrentDirectory + @"\" + "MoonTodoList-UnitTest.txt";
            var persistence = new TextPersistence(filePath);
            persistence.Save(new List<TodoItem>()
            {
                new TodoItem(1, "a"),
                new TodoItem(2, "b"),
                new TodoItem(3, "c")
            });

            var lines = File.ReadAllLines(filePath);
            Assert.Equal(3, lines.Length);
        }
    }
}