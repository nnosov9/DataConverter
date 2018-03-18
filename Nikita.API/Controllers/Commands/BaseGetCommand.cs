 
using Nikita.API.Controllers.Commands.Interfaces;
using Nikita.Lib.Domain;

namespace Nikita.API.Controllers.Commands
{
    public abstract class BaseGetCommand<T> : ICommandGet<T>
    {                             
        protected abstract T RunQuery();
        public T Execute()
        {
            return RunQuery();
        }
    }     
   
}