using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nikita.API.Models.Interfaces;
using Nikita.Lib.Interfaces;

namespace Nikita.API.Controllers.Commands.Interfaces
{
    public interface IPeopleCommandFactory
    {
        ICommandGet<IPersonList> GetGetPersonListCommand(string sort);    
        ICommandPut GetPutPersonCommand(string personData);
    }
}