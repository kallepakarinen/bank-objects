using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bank_objects
{
    class Account
    {
        private string _accountNumber;
        private List<Transaction> _accountEvents = new List<Transaction>();
        private double _balance;

        public Account(string accountNumber)
        {
            _accountNumber = accountNumber;
        }

        public string AccountNumber
        {
            get { return _accountNumber; }
            set { _accountNumber = value; }
        }

        public double Balance
        {
            get { return _balance; }
            set { _balance = value; }
        }

        public bool AddEvent(Transaction Event)
        {
            bool accept = false;
            _accountEvents.Add(Event);
            double currentBalance = _balance;
            if (_accountEvents.Last().Equals(Event))
            {
                _balance += Event.Sum;
            }
            if (_balance - Event.Sum == currentBalance)
            {
                accept = true;
            }
            return accept;
        }

        public List<Transaction> GetEventsTimeSpan(DateTime start, DateTime end)
        {
            List<Transaction> list = (from Transaction in _accountEvents
                                      where Transaction.TimeStamp >= start && Transaction.TimeStamp <= end
                                      orderby Transaction.TimeStamp
                                      select Transaction).ToList();
            return list;
        }
    }

}
