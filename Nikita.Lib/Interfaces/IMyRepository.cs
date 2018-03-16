using System.Collections.Generic;

namespace Nikita.Lib.Interfaces
{

    public interface IMyRepository<T>
    {
        void Add(T person);
        void Add(IEnumerable<T> people);
        IEnumerable<T> Get();
    }
}
