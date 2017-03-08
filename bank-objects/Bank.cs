using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bank_objects
{
    public class Bank
    {
        private string _bankName;
        private List<Account> _accounts;
        private Random _randomAcc = new Random();
   
        public string CreateNewBankAccount()
        {
            Account account = new Account(RandomlyAccountNumber());
            _accounts.Add(account);
            return account.AccountNumber;
        }
        
        private string RandomlyAccountNumber()
        {
            string StringAccount = "";

            for (int i = 0; i < 15; i++)
            {
                StringAccount += _randomAcc.Next(1, 10).ToString();
            }
            string FinalAccount = "FI" + StringAccount;
            return FinalAccount;
        }

        public Bank(string bankName)
        {
            _bankName = bankName;
            _accounts = new List<Account>();
        }

        public string BankName
        {
            get { return _bankName; }
            set { _bankName = value; }
        }


        public bool NewAccountEvent(string FinalAccount, Transaction TransactionEvent)
        {
            return (from account in _accounts
                    where account.AccountNumber == FinalAccount
                    select account).First().AddEvent(TransactionEvent);
        }

        public double GetBalance(string AccountNumber)
        {
            return (from account in _accounts
                    where account.AccountNumber == AccountNumber
                    select account).FirstOrDefault().Balance;
        }

        public List<Transaction> GetEvents(string AccountNumber, DateTime start, DateTime end)
        {
            return (from account in _accounts
                    where account.AccountNumber == AccountNumber
                    select account).FirstOrDefault().GetEventsTimeSpan(start, end);
        }
    }

}
