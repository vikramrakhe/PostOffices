using System.Collections.Generic;

namespace PostOffices
{
    public class TreeBasedPostOfficeNameCompleter
    {
        public TreeBasedPostOfficeNameCompleter(List<string> postOffices)
        {
        }

        public IEnumerable<string> SuggestCompletedNames(string startOfName)
        {
            return new List<string>(){"a"};
        }
    }
}