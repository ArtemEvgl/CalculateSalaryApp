using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    class CsvSettings
    {
        public CsvSettings(char delimiter, string path)
        {
            Delimiter = delimiter;
            Path = path;
        }

        public char Delimiter { get; }

        public string Path { get; }

    }
}
