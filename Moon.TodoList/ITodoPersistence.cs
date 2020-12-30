using System.Collections.Generic;

namespace Moon.TodoList
{
    public interface ITodoPersistence
    {
        void Save(IEnumerable<string> enumerable);

        IEnumerable<string> Read();
    }
}