using Nikita.Lib.Interfaces;

namespace Nikita.Lib.Data
{                
    public class DataStorage  :IDataStorage
    {
        public DataStorage()
        {
            _people = new PersonRepository();
        }
        private PersonRepository _people { get; set; }

        public PersonRepository  People()
        {
            return _people;
        }
    } 
}
