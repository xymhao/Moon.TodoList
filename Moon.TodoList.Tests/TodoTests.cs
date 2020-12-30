using Xunit;

namespace Moon.TodoList.Tests
{
    public class TodoTests
    {
        [Fact]
        public void Should_Success_When_Add_Item_Abc()
        {
            var todo = new Todo(null);

            todo.Add("abc");
        }
    }
}