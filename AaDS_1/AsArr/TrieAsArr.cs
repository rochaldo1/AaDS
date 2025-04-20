namespace AaDS_1.AsArr
{
    public class TrieAsArr
    {
        private NodeAsArr _root;

        public TrieAsArr()
        {
            _root = new NodeAsArr();
        }

        public void Insert(string word)
        {
            NodeAsArr current = _root;

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
