using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nikita.API.Controllers.Commands.Interfaces;
using Nikita.Lib.Data;
using Nikita.Lib.Domain;
using Nikita.Lib.Interfaces;

namespace Nikita.API.Controllers.Commands
{
    public class PeopleCommandFactory : IPeopleCommandFactory
    {
        private PersonService _service;
        private PersonParser _personParser;
        private HeaderParser _headerParser;
        public PeopleCommandFactory( IService personService, PersonParser personParser, HeaderParser headerParser)
        {
             _service = personService as PersonService;
            _personParser = personParser as PersonParser;
            _headerParser = headerParser as HeaderParser;
        }

        public ICommandGet<IPersonList> GetGetPersonListCommand(string sort)
        {
            return new PersonGetCommand(_service, sort);
        } 

        public ICommandPut GetPutPersonCommand(string personData)
        {
            return new PersonPutCommand(_service, personData, _personParser, _headerParser);
        }
    }
}