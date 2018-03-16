using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;             
using DataConverter.Config;      
using Nikita.Lib.Data;
using Nikita.Lib.Interfaces;
using Unity;

namespace DataConverter
{
    class Program
    {
        static   List<string> myData =   new List<string>() 
        {
           // @"C:\nikita.workspace\input\data_v1.txt",
          //  @"C:\nikita.workspace\input\data_v2.txt",
            @"C:\nikita.workspace\input\data_v3.txt",
          //  @"C:\nikita.workspace\input\data_v4.txt",
            //@"C:\nikita.workspace\input\data_bad.txt",
            //@"C:\nikita.workspace\input\data_idonotexist.txt"
        };

        static void Main(string[] args)
        {
            Console.WriteLine("running...");
            Start();  
            Console.WriteLine("done.");
            Console.Read();
        }
       
        static void Start()
        {
            Console.WriteLine("registering dependencies...");
            var container = UnityConfig.GetConfiguredContainer();
            var commandFactory = container.Resolve<IDataProcessorCommandFactory>();

            ProcessData(commandFactory.GetProcessPersonDataCommand(myData));
            DisplayData(commandFactory.GetGetPersonRecordsCommand());   
        }

        static void ProcessData(ICommandPut  command)
        {                                       
            command.Execute();
        }

        static void DisplayData(ICommandGet<Person> command)
        {
            var people = command.Execute();
            DisplayData("Output 1", people.OrderBy(_ => _.Gender).ThenBy(_ => _.LastName));
            DisplayData("Output 2", people.OrderBy(_ => _.DateOfBirth));
            DisplayData("Output 3", people.OrderByDescending(_ => _.LastName));
        }
        static void DisplayData(string outputName, IEnumerable<Person> people)
        {
            Console.WriteLine("");
            Console.WriteLine(outputName);
            Console.WriteLine(Repeat("_",92));
            Console.Write("|".PadRight(2));
            Console.Write("FirstName".PadRight(20));
            Console.Write("LastName".PadRight(20));
            Console.Write("DateOfBirth".PadRight(20));
            Console.Write("Gender".PadRight(10));
            Console.Write("FavoriteColor".PadRight(20));   
            Console.WriteLine("|");
            Console.WriteLine(Repeat("-", 92));
            foreach (var person in people)
            {
                Console.Write("|".PadRight(2));
                Console.Write(person.FirstName.PadRight(20));
                Console.Write(person.LastName.PadRight(20));
                Console.Write(person.DateOfBirth?.Date.ToShortDateString().PadRight(20));
                Console.Write(person.Gender.PadRight(10));
                Console.Write(person.FavoriteColor.PadRight(20));
                Console.WriteLine("|");

            }
            Console.WriteLine(Repeat("_", 92));

        }
        static string Repeat(string value, int count)
        {
            return new StringBuilder(value.Length * count).Insert(0, value, count).ToString();
        }

    }
}
