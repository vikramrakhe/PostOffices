using System.Collections.Generic;
using System.Linq;

namespace PostOffices
{
    public class SimplePostOfficeNameCompleter
    {
        public IEnumerable<string> SuggestCompletedNames(string startOfName)
        {
            var file = new PostOfficeDataFile();
            var postOffices = file.Read();

            var listOfMatchingOfficeNames = postOffices.Where(s => s.StartsWith(startOfName)).Distinct().DefaultIfEmpty();

            return listOfMatchingOfficeNames.DefaultIfEmpty();
        }
    }
}
