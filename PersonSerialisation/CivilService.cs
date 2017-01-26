using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PersonSerialisation
{
    class CivilService
    {
        private static string pathMaternity = @"C:\temp\data\PersonSerialisation\Maternity.txt";
        private static BinaryFormatter binaryFormatterPersons = new BinaryFormatter();
        public static void Get()
        {
            Console.WriteLine("Which ID registry do you wish to view?");
            int givenNumber = 0;
            bool isANumber = int.TryParse(Console.ReadLine().Trim(), out givenNumber);
            while (isANumber == false)
            {
                Console.WriteLine("Input was not a number.");
                Console.WriteLine("Which ID registry do you wish to view?");
                isANumber = int.TryParse(Console.ReadLine().Trim(), out givenNumber);
            }
            bool found = false;
            using (StreamReader reader = new StreamReader(pathMaternity))
            {
                List<Person> personsFromFile = new List<Person>();
                personsFromFile = (List<Person>)binaryFormatterPersons.Deserialize(reader.BaseStream);
                foreach (Person personInList in personsFromFile)
                {
                    int tempNumber = int.Parse(personInList.IDnr);
                    if (tempNumber == givenNumber)
                    {
                        found = true;
                        Console.WriteLine(string.Format("Requested ID {0} belongs to: \n{1}\t{2}\nBorn on: {3}", personInList.IDnr, personInList.LastName, personInList.FirstName, personInList.BirthDate));
                    }
                }
            }
            if (found == false)
            {
                bool choiceKey = false;
                while (choiceKey == false)
                {
                    Console.WriteLine("Requested ID {0} has no matching values. Try again? (Y/N)", givenNumber);
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    switch (key.Key)
                    {
                        case ConsoleKey.N:
                            choiceKey = true;
                            break;
                        case ConsoleKey.Y:
                            choiceKey = true;
                            Get();
                            break;
                        default:
                            Console.Clear();
                            Console.WriteLine("Input was neither Y nor N.");
                            break;
                    }
                }
            }
        }

        /*
         * Schrijf in deze console applicatie een tweede programme waarin de file met personen ingelezen wordt en in een array wordt gestoken. Vraag daarna aan de gebruiker om een rijksregisternummer in te geven en toon de gegevens van de bijhorende persoon.
         * */
    }
}
