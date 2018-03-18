using System.Collections.Generic;       
using Nikita.Lib.Data;
using Nikita.Lib.Domain;
using Nikita.Lib.Interfaces;

namespace DataConverter.Commands
{
    public class ProcessPersonDataCommand : BaseProcessFileCommand<Person>
    {
        private PersonService _service;

        public ProcessPersonDataCommand(IEnumerable<string> filepath, IParser dataFileParser, PersonService service) :
            base(filepath, dataFileParser)
        {
            _service = service;
        }

        protected override void ProcessData()
        {
            foreach (var file in Files)
            {
                var df = DataFileParser.Parse(file);
                _service.Add(df.Items);
            }
        }
    }
}
