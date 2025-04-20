namespace AaDS_1.AsList
{
    public class NodeAsList
    {
        private class ListNode
        {
            public char Character { get; }
            public NodeAsList Node { get; set; }
            public ListNode Next { get; set; }

            public ListNode(char character, NodeAsList node, ListNode next = null)
            {
                Character = character;
                Node = node;
                Next = next;
            }
        }

        private ListNode _head;
        public bool IsEndOfWord { get; set; }

        public void AddChild(char character)
        {
            if (!ContainsChild(character))
            {
                _head = new ListNode(character, new NodeAsList(), _head);
            }
        }

        public NodeAsList? GetChild(char character)
        {
            ListNode current = _head;
            while (current != null)
            {
                if (current.Character == character)
                {
                    return current.Node;
                }
                current = current.Next;
            }
            return null;
        }

        public bool ContainsChild(char character)
        {
            ListNode current = _head;
            while (current != null)
            {
                if (current.Character == character)
                {
                    return true;
                }
                current = current.Next;
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

            var children = new List<(char, NodeAsList)>();
            ListNode current = _head;
            while (current != null)
            {
                children.Add((current.Character, current.Node));
                current = current.Next;
            }

            for (int i = 0; i < children.Count; i++)
            {
                var (ch, node) = children[i];
                bool isLastChild = i == children.Count - 1;
                node.PrintTree(prefix + (isLast ? "    " : "│   "), isLastChild, ch);
            }
        }
    }
}