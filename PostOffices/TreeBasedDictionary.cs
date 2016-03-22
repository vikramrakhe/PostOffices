using System.Collections.Generic;

namespace PostOffices
{
    public class TreeBasedDictionary
    {
        private readonly DictionaryNode m_Root = new DictionaryNode();

        public void Add(string word)
        {
            m_Root.Add(word);
        }

        public DictionaryNode Find(string startOfName)
        {
            return m_Root.Find(startOfName);
        }

        public IEnumerable<string> Words()
        {
            return m_Root.Words();
        }
    }
}