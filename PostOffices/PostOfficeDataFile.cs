using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace PostOffices
{
    public class PostOfficeDataFile
    {
        public IEnumerable<PostOffice> Read()
        {
            const string fileName = "all_india_PO_list_without_APS_offices_ver2.csv";
            var directory = Assembly.GetExecutingAssembly().CodeBase;
            var x = new Uri(directory);
            var xx = Path.GetDirectoryName(x.AbsolutePath);
            var filePath = Path.Combine(xx, fileName);
            var lines = File.ReadAllLines(filePath);
            return lines.Select(line => new PostOffice());
        }
    }
}