using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace PersonSerialisation
{
    class Maternity
    {
        private static string pathMaternity = @"C:\temp\data\PersonSerialisation\Maternity.txt";
        private static BinaryFormatter binaryFormatterPersons = new BinaryFormatter();
        public static void Add()
        {
            Console.WriteLine("What is the first name of the newborn?");
            string firstName = Console.ReadLine().Trim();
            Console.WriteLine("What is the last name of the newborn?");
            string lastName = Console.ReadLine().Trim();
            int highestNumber = 0;
            using (StreamReader reader = new StreamReader(pathMaternity))
            {
                List<Person> personsFromFile = new List<Person>();
                personsFromFile = (List<Person>)binaryFormatterPersons.Deserialize(reader.BaseStream);
                foreach (Person personInList in personsFromFile)
                {
                    int tempNumber = int.Parse(personInList.IDnr);
                    if (tempNumber > highestNumber)
                    {
                        highestNumber = tempNumber;
                    }
                }
                Person person = new Person(firstName, lastName, (highestNumber + 1).ToString(), DateTime.Now);
                using (StreamWriter writer = new StreamWriter(pathMaternity, true))
                {
                    binaryFormatterPersons.Serialize(writer.BaseStream, person);
                }
            }
        }
    }
}
