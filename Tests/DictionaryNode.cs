using System.Collections.Generic;

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
    }
}