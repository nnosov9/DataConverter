using System.Collections.Generic;
using Nikita.Lib.Data;
using Nikita.Lib.Interfaces;

namespace Nikita.Lib.Commands
{
   public class ProcessPersonDataCommand : BaseProcessFileCommand<Person>
    {
        public ProcessPersonDataCommand(IEnumerable<string> filepath,  IParser dataFileParser, IDataStorage dataStorage) : base(filepath, dataFileParser, dataStorage)
        {
             
        }

        protected override void ProcessData()
        {                                              
            foreach (var file in Files)
            {
                var df = DataFileParser.Parse(file);
                DataStorage.People().Add(df.Items);                                                                             
            }                                        
        }
    }
}
