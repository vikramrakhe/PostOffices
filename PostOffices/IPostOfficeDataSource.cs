using System.Collections.Generic;

namespace PostOffices
{
    public interface IPostOfficeDataSource
    {
        IEnumerable<string> Read();
    }
}