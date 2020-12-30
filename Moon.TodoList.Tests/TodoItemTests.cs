using Xunit;

namespace Moon.TodoList.Tests
{
    public class TodoItemTests
    {
        [Fact]
        public void Should_Ctor_By_Record()
        {
            var record = "1 todoItem1 false";
            var todo = new TodoItem(record);
            
            Assert.Equal(1, todo.Index);
            Assert.Equal("todoItem1", todo.Content);
            Assert.False(todo.Complete);

        }
    }
}