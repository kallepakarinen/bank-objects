using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace bank_objects
{
    public class Person
    {
        private string _firstName;
        private string _lastName;
        private string _accountNumber;

        public Person(string firstName, string lastName, string accountNumber)
        {
            _firstName  = firstName;
            _lastName = lastName;
            _accountNumber = accountNumber;
        }

        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        public string AccountNumber
        {
            get {return _accountNumber; }
            set { _accountNumber = value; }
        }

        public override string ToString()
        {
            return $"Nimi {_firstName } {_lastName } Tilinumero {_accountNumber }";
        }


    }
}
