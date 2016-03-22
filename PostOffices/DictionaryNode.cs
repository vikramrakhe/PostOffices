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
                DictionaryNode childNode;
                if (!currentNode.m_Nodes.TryGetValue(c, out childNode))
                {
                    childNode = new DictionaryNode();
                    currentNode.m_Nodes.Add(c, childNode);
                }
                currentNode = childNode;
            }
            currentNode.IsWord = true;
        }

        public DictionaryNode Find(string wordFragment)
        {
            var currentNode = this;
            foreach (var c in wordFragment)
            {
                DictionaryNode childNode;
                if (!currentNode.m_Nodes.TryGetValue(c, out childNode)) return null;
                currentNode = childNode;
            }
            return currentNode;
        }

        public IEnumerable<string> Words()
        {
            return Words(string.Empty);
        }

        private IEnumerable<string> Words(string wordFragment)
        {
            var myWord = IsWord ? new List<string>{wordFragment} : new List<string>();
            return myWord.Concat(m_Nodes.SelectMany(pair => pair.Value.Words(wordFragment + pair.Key)));
        }
    }
}