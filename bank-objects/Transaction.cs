using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bank_objects
{
    public class Transaction
    {
        private readonly DateTime _timeStamp;
        private readonly double _sum;

        //Constructors
        public Transaction(DateTime TimeStamp, double Sum)
        {
            _timeStamp = TimeStamp;
            _sum = Sum;
        }

        //Properties
        public DateTime TimeStamp
        {
            get { return _timeStamp; }
        }

        public double Sum
        {
            get { return _sum; }
        }

    }
}
