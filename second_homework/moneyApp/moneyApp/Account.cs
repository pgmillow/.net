using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace moneyApp
{
    public class Account
    {
        private string username;
        private string password;
        private decimal balance;
        private double creditLimit;
        public Account(string username, string password, decimal balance, double creditLimit)
        {
            this.username = username;
            this.password = password;
            this.balance = balance;
            this.creditLimit = creditLimit;
        }
        public virtual void Withdraw(decimal amount)
        {
            if (amount > Balance)
                throw new InvalidOperationException("余额不足！.");
            Balance -= amount;
        }
        public void Deposit(decimal amount)
        {
            Random random = new Random();
            if (random.NextDouble() < 0.3) // 30% 的概率
                throw new BadCashException("收到坏钞，存款失败。");
            Balance += amount;
        }
        public string Username
        {
            get { return username; }
            set { username = value; }
        }
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        public decimal Balance
        {
            get { return balance; }
            set { balance = value; }
        }
        public double CreditLimit
        {
            get { return creditLimit; }
            set { creditLimit = value; }
        }
    }
}