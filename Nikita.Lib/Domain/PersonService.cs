using System.Collections.Generic;
using Nikita.Lib.Data;
using Nikita.Lib.Interfaces;

namespace Nikita.Lib.Domain
{
    public class PersonService : BaseDomainService<Person>
    {
       
        public PersonService(IDataStorage storage):base(storage) { }
            
        public override void Add(Person model)
        {
            DataStorage.People().Add(model);      
        }

        public override void Add(IEnumerable<Person> model)
        {
           DataStorage.People().Add(model);
        }

        public override IEnumerable<Person> GetAll()
        {
           
            return DataStorage.People().Get();
        }
    }
}
