using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonSerialisation
{
    [Serializable]
    class Person
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string IDnr { get; private set; }
        public DateTime BirthDate { get; private set; }
        public Person(string firstName, string lastName, string idNr, DateTime birthDate)
        {
            FirstName = firstName;
            LastName = lastName.ToUpper();
            IDnr = idNr;
            BirthDate = birthDate;
        }
    }
}
