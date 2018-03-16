using System.Collections.Generic;
using Nikita.Lib.Data;
using Nikita.Lib.Interfaces;

namespace Nikita.Lib.Commands
{
    public class DataProcessorCommandFactory : IDataProcessorCommandFactory
    {
        private IParser _dataFileParser;
        private IDataStorage _dataStorage;

        public DataProcessorCommandFactory(IParser dataFileParser, IDataStorage dataStorage)
        {
            _dataFileParser = dataFileParser;
            _dataStorage = dataStorage;
        }

        public ICommandPut GetProcessPersonDataCommand(IEnumerable<string> filePath)
        {
            return new ProcessPersonDataCommand(filePath, _dataFileParser, _dataStorage);
        }

        public ICommandGet<Person> GetGetPersonRecordsCommand()
        {
            return new GetPersonDataCommand(_dataStorage);
         }
    }


}
