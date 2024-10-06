using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace moneyApp
{
    public class CreditAccount : Account
    {
        public CreditAccount(string username, string password, decimal balance, double creditLimit) : base(username, password, balance, creditLimit)
        {
        }

        public override void Withdraw(decimal amount)
        {
            if (amount > Balance + CreditLimit)
                throw new InvalidOperationException("Exceeded credit limit.");
            base.Withdraw(amount);
        }

        public decimal CreditLimit { get; set; }
}
}
