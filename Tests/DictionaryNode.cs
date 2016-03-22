using System.Collections.Generic;
using System.Linq;
using NUnit.Framework.Constraints;

namespace Tests
{
    public class DictionaryNode
    {
        private readonly Dictionary<char, DictionaryNode> m_Nodes = new Dictionary<char, DictionaryNode>();
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
        }

        public DictionaryNode Find(string word)
        {
            var currentNode = this;
            foreach (var c in word)
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

        private IEnumerable<string> Words(string wordStem)
        {
            if (m_Nodes.Count == 0) return new List<string>{wordStem};
            return m_Nodes.SelectMany(pair => pair.Value.Words(wordStem + pair.Key));
        }
    }
}