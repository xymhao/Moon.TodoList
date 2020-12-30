namespace Moon.TodoList
{
    public class TodoItem
    {
        public TodoItem(string record)
        {
            var args = record.Trim().Split(' ');
            Index = int.Parse(args[0]);
            Content = args[1];
            Complete = bool.Parse(args[2]);
        }

        public TodoItem(int index, string content)
        {
            Index = index;
            Content = content;
            Complete = false;
        }

        /// <summary>
        /// 代办索引号
        /// </summary>
        public int Index { get; private set; }

        /// <summary>
        /// 代办内容
        /// </summary>
        public string Content { get; private set; }

        /// <summary>
        /// 是否完成
        /// </summary>
        public bool Complete { get; private set; }

        public override string ToString()
        {
            return $"{Index} {Content} {Complete}";
        }
    }
}