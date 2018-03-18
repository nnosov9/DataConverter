using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using Nikita.API.Models;
using Nikita.Lib.Data;
using Nikita.Lib.Domain;
using Nikita.Lib.Interfaces;

namespace Nikita.API.Controllers.Commands
{
    public class PersonGetCommand : BaseGetCommand<IPersonList>
    {
        private PersonService _service;
        private string _sort;

        public PersonGetCommand(PersonService service, string sort)
        {
            _sort = sort;
            _service = service;
        }

        protected override IPersonList RunQuery()
        {
            var people = _service.GetAll();
            if (_sort.Equals("name", StringComparison.OrdinalIgnoreCase))
            {
                return new PersonList()
                {
                    Count = people.Count(),
                    Items = people.OrderBy(_ => _.FirstName).ThenBy(_ => _.LastName).ToList()
                };
            }
            else if (_sort.Equals("gender", StringComparison.OrdinalIgnoreCase))
            {
                return new PersonList()
                {
                    Count = people.Count(),
                    Items = people.OrderBy(_ => _.Gender).ToList()
                };
            }
            else if (_sort.Equals("birthdate", StringComparison.OrdinalIgnoreCase))
            {
                return new PersonList()
                {
                    Count = people.Count(),
                    Items = people.OrderBy(_ => _.DateOfBirth).ToList()
                };
            }

            return new PersonList() {Count = people.Count(), Items = people.ToList()};

        }

    }
}