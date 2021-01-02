using Xunit;

namespace Moon.TodoList.Tests
{
    public class TodoItemTests
    {
        [Fact]
        public void Should_Ctor_By_()
        {
            var todo = new TodoItem(1, "todo item 1");
            
            Assert.Equal(1, todo.Index);
            Assert.Equal("todo item 1", todo.Content);
            Assert.False(todo.Complete);

        }
    }
}