using System;
using System.Web.Http;
using System.Web.Http.Results;
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
        public IHttpActionResult PutPerson(PersonDataPut personData)
        {
            try
            {
                var command = _dataProcessorCommandFactory.GetPutPersonCommand(personData.Data);
                command.Execute();

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return Ok();
        }

        [Route("{sort}")]
        public IHttpActionResult GetPeople(string sort)
        {
            try
            {
                var command = _dataProcessorCommandFactory.GetGetPersonListCommand(sort);
                var people = command.Execute();
                return Ok(  people);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}