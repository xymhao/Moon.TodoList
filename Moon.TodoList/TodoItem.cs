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

        public int Index { get; private set; }

        public string Content { get; private set; }

        public bool Complete { get; private set; }
    }
}