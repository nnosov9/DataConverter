using System.Collections.Generic;
using Nikita.Lib.Data;

namespace Nikita.Lib.Interfaces
{
    public interface IDataFile<T>  
    {
          DataMeta Meta { get; set; }
          IList<T> Items { get; set; }
          IList<DataError> Errors { get; set; }  
    }
}
