namespace AaDS_1.AsDict
{
    public class TrieAsDict
    {
        private NodeAsDict _root;

        public TrieAsDict()
        {
            _root = new NodeAsDict();
        }

        public void Insert(string word)
        {
            NodeAsDict current = _root;

            foreach (char ch in word)
            {
                if (!current.ContainsChild(ch))
                    current.AddChild(ch);
                current = current.GetChild(ch);
            }

            current.IsEndOfWord = true;
        }

        public bool Search(string word)
        {
            NodeAsDict current = _root;

            foreach (char ch in word)
            {
                if (!current.ContainsChild(ch))
                    return false;
                current = current.GetChild(ch);
            }

            return current.IsEndOfWord;
        }

        public void PrintTree()
        {
            _root.PrintTree();
        }
    }
}
