using System;      
using Nikita.API.Controllers.Commands.Interfaces;

namespace Nikita.API.Controllers.Commands
{
    public abstract class BasePutCommand   :ICommandPut
    {
        public void Execute()
        {
            ProcessRequest();
        }

        protected abstract void ProcessRequest();
    }  
}