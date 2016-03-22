using System.Collections.Generic;
using System.Linq;

namespace PostOffices
{
    public class DictionaryNode
    {
        private readonly Dictionary<char, DictionaryNode> m_Nodes = new Dictionary<char, DictionaryNode>();
        public bool IsWord { private get; set; }

        public DictionaryNode FindNodeOrNull(char c)
        {
            DictionaryNode childNode;
            m_Nodes.TryGetValue(c, out childNode);
            return childNode;
        }

        public DictionaryNode FindNodeOrAdd(char c)
        {
            DictionaryNode childNode;
            if (!m_Nodes.TryGetValue(c, out childNode))
            {
                childNode = new DictionaryNode();
                m_Nodes.Add(c, childNode);
            }
            return childNode;
        }

        public IEnumerable<string> Words(string wordFragment)
        {
            var myWord = IsWord ? new List<string>{wordFragment} : new List<string>();
            return myWord.Concat(m_Nodes.SelectMany(pair => pair.Value.Words(wordFragment + pair.Key)));
        }
    }
}