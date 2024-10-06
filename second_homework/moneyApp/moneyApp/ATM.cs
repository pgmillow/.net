using System;

namespace moneyApp
{
    internal class ATM
    {
        public event EventHandler<BigMoneyArgs> Withdrawn;

        public void Withdraw(Account account, decimal amount)
        {
            if (amount % 100 != 0)
                throw new BadCashException("金额必须是100的倍数.");

            Random random = new Random();
            // 模拟坏钞率为30%
            if (random.NextDouble() < 0.3) // 30% 的概率
                throw new BadCashException("收到坏钞.");

            if (account is CreditAccount creditAccount)
            {
                if (amount > creditAccount.Balance + creditAccount.CreditLimit)
                    throw new InvalidOperationException("超出信用额度.");
            }
            else
            {
                if (amount > account.Balance)
                    throw new InvalidOperationException("资金不足.");
            }

            account.Withdraw(amount);
            Withdrawn?.Invoke(this, new BigMoneyArgs(account, amount));
        }
    }
}
