using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nikita.Lib.Data
{
    public interface IDataFile<T>  
    {
          DataMeta Meta { get; set; }
          IList<T> Items { get; set; }
          IList<DataError> Errors { get; set; }  
    }
}
