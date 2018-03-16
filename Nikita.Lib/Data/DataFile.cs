using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nikita.Lib.Data
{
    public class DataFile<T> : IDataFile<T>
    {
        public DataFile()
        {
            Meta = new DataMeta();
            Items = new List<T>(); 
            Errors = new List<DataError>();
        }

        public DataMeta Meta { get; set; }
        public IList<T> Items { get; set; }
        public IList<DataError> Errors { get; set; }
    }

    public class DataError
    {
        public  Exception Exception { get; set; }
        public string RawData { get; set; }
    }
}
