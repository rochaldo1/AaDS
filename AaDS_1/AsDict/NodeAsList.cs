namespace AaDS_1.AsList
{
    public class NodeAsList
    {
        private class ChildNode
        {
            public char Character { get; }
            public NodeAsList Node { get; }

            public ChildNode(char character, NodeAsList node)
            {
                Character = character;
                Node = node;
            }
        }

        private readonly List<ChildNode> _children = new();
        public bool IsEndOfWord { get; set; }

        public void AddChild(char character)
        {
            if (!ContainsChild(character))
            {
                _children.Add(new ChildNode(character, new NodeAsList()));
            }
        }

        public NodeAsList GetChild(char character)
        {
            foreach (var child in _children)
            {
                if (child.Character == character)
                {
                    return child.Node;
                }
            }
            return null;
        }

        public bool ContainsChild(char character)
        {
            foreach (var child in _children)
            {
                if (child.Character == character)
                {
                    return true;
                }
            }
            return false;
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

            int count = _children.Count;
            for (int i = 0; i < count; i++)
            {
                var child = _children[i];
                bool isLastChild = i == count - 1;
                child.Node.PrintTree(prefix + (isLast ? "    " : "│   "), isLastChild, child.Character);
            }
        }
    }
}
