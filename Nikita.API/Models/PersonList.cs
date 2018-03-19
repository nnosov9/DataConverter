 
using System.Collections.Generic;    
using Newtonsoft.Json;
using Nikita.API.Models.Interfaces;
using Nikita.Lib.Data;
using Nikita.Lib.Interfaces;

namespace Nikita.API.Models
{
    public class PersonList : IPersonList
    {
        [JsonProperty(Order = 10)]
        public int? Count { get; set; }

        [JsonProperty(Order=20)]
        public IList<Person> Items { get; set; }

    }
}