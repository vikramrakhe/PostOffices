using System.Collections.Generic;

namespace PostOffices
{
    public class TreeBasedPostOfficeNameCompleter
    {
        private readonly TreeBasedDictionary m_Dictionary = new TreeBasedDictionary();

        public TreeBasedPostOfficeNameCompleter(IEnumerable<string> postOffices)
        {
            foreach (var postOffice in postOffices)
            {
                m_Dictionary.Add(postOffice);
            }
        }

        public IEnumerable<string> SuggestCompletedNames(string startOfName)
        {
            if (startOfName.Length == 0) return new List<string>();
            var nodeAtStartOfWord = m_Dictionary.Find(startOfName);
            return nodeAtStartOfWord == null ? new List<string>() : nodeAtStartOfWord.Words();
        }
    }
}