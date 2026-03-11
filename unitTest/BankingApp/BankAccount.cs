using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp
{
    public class BankAccount
    {
        public decimal Balance { get; private set; }

        public BankAccount(decimal initialBalance)
        {
            Balance = initialBalance;
        }

        public void TransferTo(BankAccount target, decimal amount)
        {
            if (target == null)
                throw new ArgumentNullException(nameof(target));

            if (amount <= 0)
                throw new ArgumentException("Amount must be positive");

            if (Balance < amount)
                throw new InvalidOperationException("Insufficient funds");

            Balance -= amount;
            target.Balance += amount;
        }
    }
}