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
    public class HeaderParserTest
    {
        private HeaderParser headerParser;
        [TestInitialize]
        public void Initialize()
        {
            headerParser = new HeaderParser();
        }

        [TestMethod]
        public void ProcessHeaderData_csv_Test()
        {
            var data = @"LastName, FirstName, Gender, FavoriteColor, DateOfBirth";
            var result = headerParser.Parse(data);
            Assert.AreEqual(result.Delimiter,',');
        }
        [TestMethod]
        public void ProcessHeaderData_pipe_Test()
        {
            var data = @"LastName | FirstName | Gender| FavoriteColor |DateOfBirth";
            var result = headerParser.Parse(data);
            Assert.AreEqual(result.Delimiter, '|');
        }
        [TestMethod]
        public void ProcessHeaderData_space_Test()
        {
            var data = @"LastName FirstName Gender FavoriteColor DateOfBirth";
            var result = headerParser.Parse(data);
            Assert.AreEqual(result.Delimiter, ' ');
        }
        [TestMethod]
        public void ProcessHeaderData_space_ValidateFields_Test()
        {
            var data = @"LastName FirstName Gender FavoriteColor DateOfBirth";
            var result = headerParser.Parse(data);
            Assert.IsTrue(result.Fields.ContainsKey("lastname"));
            Assert.IsTrue(result.Fields.ContainsKey("firstname"));
            Assert.IsTrue(result.Fields.ContainsKey("gender"));
            Assert.IsTrue(result.Fields.ContainsKey("favoritecolor"));
            Assert.IsTrue(result.Fields.ContainsKey("dateofbirth"));

                                                             
        }
    }
}
