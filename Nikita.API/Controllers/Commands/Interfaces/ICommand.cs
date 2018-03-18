using System.Collections.Generic;

namespace Nikita.API.Controllers.Commands.Interfaces
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
         T Execute();
    }
}
