using System.Linq;

namespace AaDS_1.AsArr
{
    public class NodeAsArr
    {
        public NodeAsArr[] Children { get; private set; }
        public bool IsEndOfWord { get; set; }

        public NodeAsArr()
        {
            Children = new NodeAsArr[26]; // Для английского алфавита
            IsEndOfWord = false;
        }

        public void AddChild(char character)
        {
            int index = character - 'a';
            if (Children[index] == null)
            {
                Children[index] = new NodeAsArr();
            }
        }

        public NodeAsArr GetChild(char character)
        {
            int index = character - 'a';
            return Children[index];
        }

        public bool ContainsChild(char character)
        {
            int index = character - 'a';
            return Children[index] != null;
        }

        public void PrintTree(string prefix = "", bool isLast = true, char ch = '\0')
        {
            Console.Write(prefix);
            Console.Write(isLast ? "└── " : "├── ");

            if (ch != '\0')
            {
                Console.WriteLine(ch + (IsEndOfWord ? " (End of Word)" : ""));
            }
            else
            {
                Console.WriteLine("Root");
            }

            for (int i = 0; i < Children.Length; i++)
            {
                if (Children[i] != null)
                {
                    char character = (char)('a' + i);
                    bool isLastChild = true;

                    for (int j = i + 1; j < Children.Length; j++)
                    {
                        if (Children[j] != null)
                        {
                            isLastChild = false;
                            break;
                        }
                    }

                    Children[i].PrintTree(prefix + (isLast ? "    " : "│   "), isLastChild, character);
                }
            }
        }
    }
}
