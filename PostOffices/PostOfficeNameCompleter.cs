using System.Collections.Generic;
using System.Linq;

namespace PostOffices
{
    public class PostOfficeNameCompleter
    {
        private readonly List<string> m_TestData;

        public PostOfficeNameCompleter(IEnumerable<string> testData)
        {
            m_TestData = testData.ToList();
        }

        public IEnumerable<string> SuggestCompletedNames(string startOfName)
        {
            return new List<string>();
        }
    }
}