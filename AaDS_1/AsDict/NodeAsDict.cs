namespace AaDS_1.AsDict
{
    public class NodeAsDict
    {
        public Dictionary<char, NodeAsDict> Children { get; private set; }
        public bool IsEndOfWord { get; set; }

        public NodeAsDict()
        {
            Children = new Dictionary<char, NodeAsDict>();
            IsEndOfWord = false;
        }

        public void AddChild(char character)
        {
            if (!Children.ContainsKey(character))
            {
                Children[character] = new NodeAsDict();
            }
        }

        public NodeAsDict GetChild(char character)
        {
            if (Children.ContainsKey(character))
            {
                return Children[character];
            }

            return null;
        }

        public bool ContainsChild(char character)
        {
            return Children.ContainsKey(character);
        }

        public void PrintTree(string prefix = "", bool isLast = true, char character = '\0')
        {
            Console.Write(prefix);
            Console.Write(isLast ? "└── " : "├── ");
            if (character != '\0')
            {
                Console.WriteLine(character + (IsEndOfWord ? " (End of Word)" : ""));
            }
            else
            {
                Console.WriteLine("Root");
            }

            int count = Children.Count;
            int index = 0;
            foreach (var child in Children)
            {
                index++;
                bool isLastChild = index == count;
                child.Value.PrintTree(prefix + (isLast ? "    " : "│   "), isLastChild, child.Key);
            }
        }
    }
}
