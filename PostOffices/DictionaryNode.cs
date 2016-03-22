using System.Collections.Generic;
using System.Linq;

namespace PostOffices
{
    public class DictionaryNode
    {
        private readonly Dictionary<char, DictionaryNode> m_Nodes = new Dictionary<char, DictionaryNode>();
        private bool IsWord { get; set; }

        public void Add(string word)
        {
            var currentNode = this;
            foreach (var c in word)
            {
                currentNode = currentNode.FindNodeOrAdd(c);
            }
            currentNode.IsWord = true;
        }

        public DictionaryNode Find(string wordFragment)
        {
            var currentNode = this;
            foreach (var c in wordFragment)
            {
                var childNode = currentNode.FindNodeOrNull(c);
                if (childNode == null) return null;
                currentNode = childNode;
            }
            return currentNode;
        }

        public IEnumerable<string> Words()
        {
            return Words(string.Empty);
        }

        private DictionaryNode FindNodeOrNull(char c)
        {
            DictionaryNode childNode;
            m_Nodes.TryGetValue(c, out childNode);
            return childNode;
        }

        private DictionaryNode FindNodeOrAdd(char c)
        {
            DictionaryNode childNode;
            if (!m_Nodes.TryGetValue(c, out childNode))
            {
                childNode = new DictionaryNode();
                m_Nodes.Add(c, childNode);
            }
            return childNode;
        }

        private IEnumerable<string> Words(string wordFragment)
        {
            var myWord = IsWord ? new List<string>{wordFragment} : new List<string>();
            return myWord.Concat(m_Nodes.SelectMany(pair => pair.Value.Words(wordFragment + pair.Key)));
        }
    }
}