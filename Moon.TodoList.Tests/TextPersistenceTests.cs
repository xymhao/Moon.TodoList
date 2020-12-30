using System;
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
            persistence.Save(new []{"1", "2", "3"});

            var lines = File.ReadAllLines(filePath);
            Assert.Equal(3, lines.Length);
        }
    }
}