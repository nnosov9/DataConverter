using System.Collections.Generic;

namespace Nikita.Lib.Interfaces
{

    public interface ICommand
    {

    }

    public interface ICommandPut : ICommand
    {
        void Execute();
    }

    public interface ICommandGet<T> : ICommand
    {
        IEnumerable<T> Execute();
    }
}
