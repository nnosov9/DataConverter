using System.Collections.Generic;
using Nikita.Lib.Data;

namespace Nikita.Lib.Interfaces
{
    public interface IDataProcessorCommandFactory
    {
        ICommandPut GetProcessPersonDataCommand(IEnumerable<string> filePaths);

        ICommandGet<Person> GetGetPersonRecordsCommand();
    }
}
