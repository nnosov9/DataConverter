using System.Net.Http;
using System.Web.Http;
using System.Web.UI.WebControls;
using Nikita.API.Controllers.Commands.Interfaces;
using Nikita.API.Models;
using Nikita.Lib.Interfaces;

namespace Nikita.API.Controllers
{
    [RoutePrefix("api/records")]
    public class PeopleController: ApiController
    {
        private IPeopleCommandFactory _dataProcessorCommandFactory;

        public PeopleController(IPeopleCommandFactory dataProcessorCommandFactory)
        {
            _dataProcessorCommandFactory = dataProcessorCommandFactory;
        }

        [HttpPost]
        [Route("")]
        public void PutPerson(PersonDataPut personData)
        {
            var command = _dataProcessorCommandFactory.GetPutPersonCommand(personData.Data);
            command.Execute();
        }
     
        [Route("{sort}")]
        public IPersonList GetPeople(string sort)
        {
            var command = _dataProcessorCommandFactory.GetGetPersonListCommand(sort);
            var people = command.Execute();
            return people;
        }
    }
}