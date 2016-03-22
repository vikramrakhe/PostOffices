using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace PostOffices
{
    public class PostOfficeDataFile : IPostOfficeDataSource
    {
        public IEnumerable<string> Read()
        {
            const string fileName = "all_india_PO_list_without_APS_offices_ver2.csv";
            var filePath = FilePath(fileName);
            var lines = File.ReadAllLines(filePath);
            return lines.Skip(1).Select(PostOfficeName);
        }

        private static string FilePath(string fileName)
        {
            var thisDll = new Uri(Assembly.GetExecutingAssembly().CodeBase).AbsolutePath;
            var directoryName = Path.GetDirectoryName(thisDll) ?? ".";
            var filePath = Path.Combine(directoryName, fileName);
            return filePath;
        }

        private static string PostOfficeName(string line)
        {
            var fields = line.Split(',');
            var name = fields[0];
            return name;
        }
    }
}