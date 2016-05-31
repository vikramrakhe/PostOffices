using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace PostOffices
{
    public class SimplePostOfficeNameCompleter
    {
        public IEnumerable<string> SuggestCompletedNames(string startOfName)
        {
            return new List<string>().DefaultIfEmpty();
        }
    }
}
