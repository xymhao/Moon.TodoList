using System.Collections.Generic;

namespace Moon.TodoList
{
    public interface ITodoPersistence
    {
        /// <summary>
        /// 持久化todo数据
        /// </summary>
        /// <param name="records">数据集合</param>
        void Save(IEnumerable<TodoItem> records);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IEnumerable<TodoItem> Read();
    }
}