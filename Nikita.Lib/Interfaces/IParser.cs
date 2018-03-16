using System.Collections.Generic;
using Nikita.Lib.Data;

namespace Nikita.Lib.Interfaces
{
    public interface IParser { }
    public interface IParser<T> : IParser
    {
         T Parse(string data);
    }

    public interface IRecordParser<T> : IParser 
    {
        T Parse(string data, DataMeta meta);
    }
}
