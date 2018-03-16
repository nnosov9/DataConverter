using System;
using System.Collections.Generic;
using System.IO;
using Nikita.Lib.Interfaces;

namespace Nikita.Lib.Data
{
    public class PersonParserException : Exception
    {
        public PersonParserException(string message,Exception e):base(message, e)   
        { 
        }
    }

    public class PersonParser  : IRecordParser<Person>
    {
        private IDictionary<int, string> _dataMeta;
        private char _delimiter;

        public Person Parse(string data, DataMeta meta)
        {
            var record = data.Split(meta.Delimiter);
            
            var person = new Person();
            try
            {
                person.LastName =  record[meta.Fields["lastname"]].Trim();
                person.FirstName = record[meta.Fields["firstname"]].Trim();   
                person.Gender = ValidateGender(record[meta.Fields["gender"]]); 
                person.DateOfBirth= Convert.ToDateTime(record[meta.Fields["dateofbirth"]]);
                person.FavoriteColor= record[meta.Fields["favoritecolor"]].Trim();
                
            }
            catch (Exception e)
            {
                //we should probably throw a custom exception here.
                throw new PersonParserException("Invalid Person raw data",e);
                //we should handle a bad record here
            }
            return person;
        }

        private string ValidateGender(string g)
        {
            g = g.Trim();
            if (g.Equals("F", StringComparison.OrdinalIgnoreCase) ||
                g.Equals("M", StringComparison.InvariantCultureIgnoreCase) ||
                g.Equals("Male", StringComparison.InvariantCultureIgnoreCase) ||
                g.Equals("Female", StringComparison.InvariantCultureIgnoreCase))

                return g.Substring(0, 1).ToUpper();
            else
                 return null;
        } 
    }

}
