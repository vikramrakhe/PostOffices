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

        public IEnumerable<string> CompleteWordsBeginningWith(string startOfWord)
        {
            var nodeAtStartOfWord = m_Root.Find(startOfWord);
            return nodeAtStartOfWord == null ? new List<string>() : nodeAtStartOfWord.Words();
        }
    }
}