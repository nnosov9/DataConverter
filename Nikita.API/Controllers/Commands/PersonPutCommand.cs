
using System.Collections.Generic;
using Nikita.Lib.Data;
using Nikita.Lib.Domain;

namespace Nikita.API.Controllers.Commands
{
    public class PersonPutCommand : BasePutCommand
    {
        private string _personData;
        private PersonService _service;
        private PersonParser _personParser;  
        private HeaderParser _headerParser;

        public PersonPutCommand(PersonService service, string personData, PersonParser personParser, HeaderParser headerParser) :base()
        {
            _service = service;
            _personData = personData;
            _personParser = personParser;
            _headerParser = headerParser;
        }

        /// <summary>
        /// Default the input data schema. since we do not have a header available.
        /// </summary>
        protected override void ProcessRequest()
        {
            var dm = _headerParser.Parse(_personData);
            //default header fields as we do not have access to the header data. in rest.api
            dm.Fields = new Dictionary<string, int>
            {
                {"firstname", 0},
                {"lastname", 1},
                {"gender", 2},
                {"favoritecolor", 3},
                {"dateofbirth", 4}
            };                  

            var person = _personParser.Parse(_personData, dm);
            _service.Add(person);
        }
    }
}