using System.Collections.Generic;
using Nikita.Lib.Data;
using Nikita.Lib.Interfaces;

namespace DataConverter.Commands
{
    public abstract class BaseGetDataCommand<T> : ICommandGet<T>
    {
    
        public BaseGetDataCommand()
        {
          
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

        protected BaseProcessFileCommand(IEnumerable<string> filepath, IParser parser )
        {                                      
            DataFileParser = parser as DataFileParser<T>; 
        
            Files = filepath;
           
        }
        public void Execute()
        { 
            ProcessData();                                
        }

        protected abstract void ProcessData();
    }
}
