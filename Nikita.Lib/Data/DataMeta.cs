using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nikita.Lib.Data
{
    public class DataMeta
    {
        public char Delimiter { get; set; }
        public IDictionary<string, int> Fields { get; set; }
        public DataError Error { get; set; }
        public DataMeta() { Fields = new Dictionary<string, int>();}
    }
}
