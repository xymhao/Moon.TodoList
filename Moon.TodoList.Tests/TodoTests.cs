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
            Assert.Equal("Item 1 added", result);
        }
    }
}