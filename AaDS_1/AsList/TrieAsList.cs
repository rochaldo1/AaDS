namespace AaDS_1.AsList
{
    public class TrieAsList
    {
        private readonly NodeAsList _root = new();

        public void Insert(string word)
        {
            NodeAsList current = _root;

            foreach (char ch in word)
            {
                if (!current.ContainsChild(ch))
                    current.AddChild(ch);
                current = current.GetChild(ch);
            }

            current.IsEndOfWord = true;
        }

        public void PrintTree()
        {
            _root.PrintTree();
        }
    }
}