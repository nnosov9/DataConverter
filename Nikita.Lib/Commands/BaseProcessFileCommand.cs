using System.Collections.Generic;
using Nikita.Lib.Data;
using Nikita.Lib.Interfaces;

namespace Nikita.Lib.Commands
{
    public abstract class BaseGetDataCommand<T> : ICommandGet<T>
    {
        protected IDataStorage DataStorage { get; }

        public BaseGetDataCommand(IDataStorage dataStorage)
        {
            DataStorage = dataStorage;
        }

        protected abstract IEnumerable<T> RunQuery();
        public IEnumerable<T> Execute()
        {
            return RunQuery();
        }
    }
   public  abstract class BaseProcessFileCommand<T>: ICommandPut 
    {
        protected IParser<T> Parser { get;   set; }
        protected DataFileParser<T> DataFileParser { get; set; }
        protected IEnumerable<string> Files { get; set; }
        protected IDataStorage DataStorage { get;  }

        protected BaseProcessFileCommand(IEnumerable<string> filepath, IParser parser, IDataStorage dataStorage)
        {
           // Parser = parser as IParser<T>;
            DataFileParser = parser as DataFileParser<T>;//IParser<IDataFile<T>>;
        
            Files = filepath;
            DataStorage = dataStorage;
        }
        public void Execute()
        { 
            ProcessData();                                
        }

        protected abstract void ProcessData();
    }
}
