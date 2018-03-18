using System.Collections.Generic;     
using Nikita.Lib.Data;
using Nikita.Lib.Domain;
using Nikita.Lib.Interfaces;

namespace DataConverter.Commands
{
    public class DataProcessorCommandFactory : IDataProcessorCommandFactory
    {
        private IParser _dataFileParser; 
        private PersonService _service;

        public DataProcessorCommandFactory(IParser dataFileParser, PersonService service)
        {
            _dataFileParser = dataFileParser;
            _service = service;
        }

        public ICommandPut GetProcessPersonDataCommand(IEnumerable<string> filePath)
        {
            return new ProcessPersonDataCommand(filePath, _dataFileParser, _service);
        }

        public ICommandGet<Person> GetGetPersonRecordsCommand()
        {
            return new GetPersonDataCommand(_service);
         }
    }


}
