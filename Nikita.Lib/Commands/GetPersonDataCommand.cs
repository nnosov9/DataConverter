using System.Collections.Generic;
using Nikita.Lib.Data;
using Nikita.Lib.Interfaces;

namespace Nikita.Lib.Commands
{
   public class GetPersonDataCommand : BaseGetDataCommand<Person>
    {
        public GetPersonDataCommand(IDataStorage dataStorage) : base(  dataStorage)
        {
             
        }       
        protected override IEnumerable<Person> RunQuery()
        {
            return DataStorage.People().Get();
         }
    }
}
