using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nikita.Lib.Data;

namespace Nikita.Lib.UnitTests
{
    [TestClass]
    public class PersonParserTest
    {
        private DataMeta dataMeta1;
        private DataMeta dataMeta2;
        private PersonParser parser;
        private Person person1;
        private string person1raw_csv = "Tsoi, Viktor, M, black, 06/21/1962";
        private string person1raw_pipe = "Tsoi| Viktor| M| black| 06/21/1962";
        private string person1raw_space = "Tsoi Viktor M black 06/21/1962";

        private string person2raw_csv = "Viktor, Tsoi, black, M, 06/21/1962";

        private string person1raw_csv_invaliddate = 
            @"Tsoi, Viktor, M, black, 13/21/1962";


        [TestInitialize]
        public void Initialize()
        {
            parser = new PersonParser();
            
            dataMeta1 = new DataMeta();
            dataMeta1.Delimiter = ',';
            dataMeta1.Fields.Add("lastname",0);
            dataMeta1.Fields.Add("firstname", 1);
            dataMeta1.Fields.Add("gender", 2);
            dataMeta1.Fields.Add("dateofbirth", 4);
            dataMeta1.Fields.Add("favoritecolor", 3);

            dataMeta2 = new DataMeta();
            dataMeta2.Delimiter = ',';
            dataMeta2.Fields.Add("lastname", 1);
            dataMeta2.Fields.Add("firstname", 0);
            dataMeta2.Fields.Add("gender", 3);
            dataMeta2.Fields.Add("dateofbirth", 4);
            dataMeta2.Fields.Add("favoritecolor", 2);

            person1 = new Person();
            person1.DateOfBirth = new DateTime(1962,06,21);
            person1.Gender = "M";
            person1.FavoriteColor = "black";
            person1.LastName = "Tsoi";
            person1.FirstName = "Viktor";

        }

        [TestMethod]
        public void RunProcessHeaderDataFormats_Tests()
        {
            dataMeta1.Delimiter = ',';
            ProcessRecordData_Test(person1raw_csv,dataMeta1);

            dataMeta1.Delimiter = '|';
            ProcessRecordData_Test(person1raw_pipe, dataMeta1);

            dataMeta1.Delimiter = ' ';
            ProcessRecordData_Test(person1raw_space, dataMeta1);

            dataMeta2.Delimiter = ',';
            ProcessRecordData_Test(person2raw_csv, dataMeta2);


        }

        [TestMethod]
        [ExpectedException(typeof(PersonParserException),
            "Invalid date was allowed")]
        public void RunParseDataGender_Tests()
        {
            dataMeta1.Delimiter = ',';
            var person = parser.Parse(person1raw_csv_invaliddate, dataMeta1);   
        }
   
        public void ProcessRecordData_Test(string data, DataMeta dm)
        {
            var person = parser.Parse(data, dm);    
            Assert.IsInstanceOfType(person, new Person().GetType());
            ComparePerson(person, person1);
        }

        private void ComparePerson(Person p1, Person p2)
        {
            Assert.AreEqual(p1.DateOfBirth,p2.DateOfBirth);
            Assert.AreEqual(p1.FavoriteColor , p2.FavoriteColor );
            Assert.AreEqual(p1.Gender, p2.Gender);
            Assert.AreEqual(p1.FirstName, p2.FirstName);
            Assert.AreEqual(p1.LastName, p2.LastName);
        }
    }    
}
