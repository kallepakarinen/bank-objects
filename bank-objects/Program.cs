using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Bank object practise
//Kalle Pakarinen
//8.3.2017
namespace bank_objects
{
    public class Program
    {
        static void Main(string[] args)
        {
            Bank bank = new Bank("Säästöpankki");
            Random rand = new Random();

            List<Person> persons = new List<Person>();

            persons.Add(new Person("Seppo", "Kekkonen", bank.CreateNewBankAccount()));
            persons.Add(new Person("Jaana", "Makkonen", bank.CreateNewBankAccount()));
            persons.Add(new Person("Heikki", "Joki", bank.CreateNewBankAccount()));

            bank.NewAccountEvent(persons[0].AccountNumber, new Transaction(new DateTime(2017, 1, 1), 500));
            bank.NewAccountEvent(persons[1].AccountNumber, new Transaction(new DateTime(2017, 1, 1), 7500));
            bank.NewAccountEvent(persons[2].AccountNumber, new Transaction(new DateTime(2017, 1, 1), -500));

            for (int i = 0; i < 20; i++)
            {
                bank.NewAccountEvent(persons[0].AccountNumber, new Transaction(new DateTime(2017, rand.Next(1, 4), rand.Next(1, 29)), Math.Round((rand.NextDouble() * rand.Next(-75, -75)), 2)));
                bank.NewAccountEvent(persons[1].AccountNumber, new Transaction(new DateTime(2017, rand.Next(1, 4), rand.Next(1, 29)), Math.Round((rand.NextDouble() * rand.Next(-75, 75)), 2)));
                bank.NewAccountEvent(persons[2].AccountNumber, new Transaction(new DateTime(2017, rand.Next(1, 4), rand.Next(1, 29)), Math.Round((rand.NextDouble() * rand.Next(-75, 75)), 2)));
            }

            ShowBalance(bank, persons[0]);
            ShowEvents(bank.GetEvents(persons[0].AccountNumber, new DateTime(2017, 1, 1), new DateTime(2017, 4, 1)), persons[0]);

            ShowBalance(bank, persons[1]);
            ShowEvents(bank.GetEvents(persons[1].AccountNumber, new DateTime(2017, 1, 1), new DateTime(2017, 4, 1)), persons[1]);

            ShowBalance(bank, persons[2]);
            ShowEvents(bank.GetEvents(persons[2].AccountNumber, new DateTime(2017, 1, 1), new DateTime(2017, 4, 1)), persons[2]);

            Console.ReadKey();
        }

        static void ShowBalance(Bank bank, Person Person)
        {
            var balance = bank.GetBalance(Person.AccountNumber);
            Console.WriteLine("{0}\nBalance: {1}\n", Person.ToString(), balance);
        }

        static void ShowEvents(List<Transaction> events, Person person)
        {
            double CurrentBalance = 0;
            for (int i = 0; i < events.Count; i++)
            {
                CurrentBalance += events[i].Sum;
                Console.WriteLine("{0}\t{1}\t{2}", events[i].TimeStamp.ToShortDateString(), events[i].Sum,
                    CurrentBalance);
            }
            Console.WriteLine("\n");
        }
    }
}






