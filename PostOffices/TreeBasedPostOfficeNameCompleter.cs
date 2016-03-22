using System.Collections.Generic;

namespace PostOffices
{
    public class TreeBasedPostOfficeNameCompleter
    {
        readonly TreeBasedDictionary m_Dictionary = new TreeBasedDictionary();

        public TreeBasedPostOfficeNameCompleter(List<string> postOffices)
        {
            postOffices.ForEach(name => m_Dictionary.Add(name));
        }

        public IEnumerable<string> SuggestCompletedNames(string startOfName)
        {
            return startOfName.Length == 0 ? new List<string>() : m_Dictionary.CompleteWordsBeginningWith(startOfName);
        }
    }
}