using System.Collections.Generic;
using System.Linq;

namespace PostOffices
{
    public class SimplePostOfficeNameCompleter
    {
        private readonly List<string> m_TestData;

        public SimplePostOfficeNameCompleter(IEnumerable<string> testData)
        {
            m_TestData = testData.ToList();
        }

        public IEnumerable<string> SuggestCompletedNames(string startOfName)
        {
            return startOfName.Length == 0
                ? new List<string>()
                : m_TestData.Where(name => name.StartsWith(startOfName))
                    .Select(name => name.Substring(startOfName.Length))
                    .Distinct();
        }
    }
}