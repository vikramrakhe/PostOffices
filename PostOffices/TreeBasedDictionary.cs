using System.Collections.Generic;

namespace PostOffices
{
    public class TreeBasedDictionary
    {
        private readonly DictionaryNode m_Root = new DictionaryNode();

        public void Add(string word)
        {
            var currentNode = m_Root;
            foreach (var c in word)
            {
                currentNode = currentNode.FindNodeOrAdd(c);
            }
            currentNode.IsWord = true;
        }

        public DictionaryNode Find(string startOfName)
        {
            var currentNode = m_Root;
            foreach (var c in startOfName)
            {
                var childNode = currentNode.FindNodeOrNull(c);
                if (childNode == null) return null;
                currentNode = childNode;
            }
            return currentNode;
        }

        public IEnumerable<string> Words()
        {
            return m_Root.Words(string.Empty);
        }
    }
}