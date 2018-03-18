using System;
using Newtonsoft.Json;
using Nikita.Lib.Interfaces;

namespace Nikita.Lib.Data
{
  
   public class Person : IPerson
    {
        [JsonProperty(Order = 10)]
        public string LastName { get; set; }
        [JsonProperty(Order = 20)]
        public string FirstName { get; set; }
        [JsonProperty(Order = 30)]
        public string Gender { get; set; }
        [JsonProperty(Order = 40)]
        public string FavoriteColor { get; set; }
        [JsonProperty(Order = 50)]
        public DateTime? DateOfBirth { get; set; }
    }
}
