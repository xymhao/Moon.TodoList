using System;
using System.Configuration;
using Xunit;

namespace Moon.TodoList.Tests
{
    public class CommandParseTests
    {
        [Fact]
        public void Should_Method_Add_When_Input_todo_add()
        {
            var commandParse = new CommandParser("todo add item1");
            Assert.Equal("add", commandParse.GetParserMethod());
        }
        
        [Fact]
        public void Should_Error_When_Input_not_contains_todo()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                var commandParse = new CommandParser("todo2 add item1");
            });
        }
    }
}