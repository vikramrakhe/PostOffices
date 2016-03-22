using System.Collections.Generic;

namespace PostOffices
{
    public class TreeBasedPostOfficeNameCompleter
    {
        readonly TreeBasedDictionary m_Dictionary = new TreeBasedDictionary();

        public TreeBasedPostOfficeNameCompleter(IEnumerable<string> postOffices)
        {
            foreach (var postOffice in postOffices)
            {
                m_Dictionary.Add(postOffice);
            }
        }

        public IEnumerable<string> SuggestCompletedNames(string startOfName)
        {
            return startOfName.Length == 0 ? new List<string>() : m_Dictionary.CompleteWordsBeginningWith(startOfName);
        }
    }
}