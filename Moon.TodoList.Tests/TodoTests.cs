using Xunit;

namespace Moon.TodoList.Tests
{
    public class TodoTests
    {
        [Fact]
        public void Should_Success_When_Add_Item_Abc()
        {
            var todo = new Todo();
            var result = todo.Add("abc");
            Assert.NotNull(result);
        }

        [Fact]
        public void Should_Throw_Exception_When_Done_Item_By_Index()
        {
            var todo = new Todo();
            Assert.Throws<TodoException>(() =>
            {
                todo.Done(100);
            });
        }
        
        [Fact]
        public void Should_Success_When_Done_Item_By_Index()
        {
            var todo = new Todo();
            todo.Add("bcd");
            var result = todo.Done(1);
            Assert.Equal("Item 1 done.", result);
        }
    }
}