using System;
using System.IO;
using System.Linq;
using Xunit;

namespace Moon.TodoList.Tests
{
    public class TodoTests
    {
        public Todo Todo { get; set; }

        public TodoTests()
        {
            var filePath = Environment.CurrentDirectory + @"\" + "MoonTodoList-UnitTest.txt";
            File.WriteAllText(filePath, "");
            Todo = new Todo(filePath);
        }

        [Fact]
        public void Should_Success_When_Add_Item_Abc()
        {
            var result = Todo.Add("abc");
            Assert.NotNull(result);
        }

        [Fact]
        public void Should_Throw_Exception_When_Done_Item_By_Index()
        {
            Assert.Throws<TodoException>(() => { Todo.Done(100); });
        }

        [Fact]
        public void Should_Success_When_Done_Item_By_Index()
        {
            Todo.Add("bcd");
            var result = Todo.Done(1);
            Assert.Equal("Item 1 done.", result);
        }

        [Fact]
        public void Should_List_When_Parameter_Default()
        {
            Todo.Add("bcd");
            Todo.Add("bcd");
            Todo.Done(1);
            var result = Todo.List(null);
            Assert.Single(result);
        }
        
        [Fact]
        public void Should_All_List_When_Parameter_All()
        {
            Todo.Add("bcd");
            Todo.Add("bcd");
            var result = Todo.List("--all");
            Assert.Equal(2,result.Count());
        }

        [Fact]
        public void Should_Exception_When_Input_Unknown_parameter()
        {
            Assert.Throws<TodoException>(() => Todo.List("--abc"));
        }
    }
}