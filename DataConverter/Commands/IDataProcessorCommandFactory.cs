using System.Collections.Generic;
using Nikita.Lib.Data;
using Nikita.Lib.Interfaces;

namespace DataConverter.Commands
{
    public interface IDataProcessorCommandFactory
    {
        DataConverter.Commands.ICommandPut GetProcessPersonDataCommand(IEnumerable<string> filePaths);

        DataConverter.Commands.ICommandGet<Person> GetGetPersonRecordsCommand();
    }
}
