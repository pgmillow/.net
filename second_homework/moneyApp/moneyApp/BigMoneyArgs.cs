using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace moneyApp
{
    public class BadCashException : Exception
    {
        public BadCashException(String message) : base(message) { }
    }
    public class BigMoneyArgs : EventArgs
    { 
        public Account Account { get; }
        public decimal Amount { get; }

        public BigMoneyArgs(Account account, decimal amount)
        {
            Account = account;
            Amount = amount;
        }
    }
}
