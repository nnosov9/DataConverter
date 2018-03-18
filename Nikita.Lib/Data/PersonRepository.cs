using System.Collections.Generic;
using System.Data;
using Nikita.Lib.Interfaces;

namespace Nikita.Lib.Data
{

    public class PersonRepository : IMyRepository<Person>
    {
        private DataTable dtPerson;

        public PersonRepository()
        {

            dtPerson = new DataTable("Person");
            dtPerson.Columns.Add("LastName");
            dtPerson.Columns.Add("FirstName");
            dtPerson.Columns.Add("Gender");
            dtPerson.Columns.Add("DateOfBirth");
            dtPerson.Columns.Add("FavoriteColor");
        }

        public void Add(IEnumerable<Person> people)
        {
            foreach (var person in people)
            {
                if (person != null)
                    Add(person);
            }
        }

        public void Add(Person p)
        {
            var person = p as Person;
            DataRow row = dtPerson.NewRow();
            row["LastName"] = person.LastName;
            row["FirstName"] = person.FirstName;
            row["DateOfBirth"] = person.DateOfBirth;
            row["FavoriteColor"] = person.FavoriteColor;
            row["Gender"] = person.Gender;

            //ValueType.new DataRow();
            dtPerson.Rows.Add(row);

        }

        public IEnumerable<Person> Get()
        {
            List<Person> people = new List<Person>();
            foreach (DataRow row in dtPerson.Rows)
            {
                people.Add(Convert(row));
            }
            return people;
        }

        private Person Convert(DataRow row)
        {
            return new Person()
            {
                DateOfBirth = System.Convert.ToDateTime(row["DateOfBirth"]),
                FavoriteColor = row["FavoriteColor"].ToString(),
                FirstName = row["FirstName"].ToString(),
                LastName = row["LastName"].ToString(),
                Gender = row["Gender"].ToString()
            };
        }

    }
}
