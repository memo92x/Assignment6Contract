using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.Contracts;

namespace Assignment6Contract
{
    class Account
    {

        private double balance;
        public double Balance { get { return balance; } }

        [ContractArgumentValidator]
        public void Deposit(double amount)
        {
            //Kræver amount er større end 0
            Contract.Requires(amount > 0);
            //Sikre at balance er samme som 0 eller større
            Contract.Ensures(Balance >= 0);
            balance += amount;
        }

        public void Withdraw(double amount)
        {
            if(amount <= 0)
            {
                throw new ArgumentException("Amount kan ikke være 0 eller mindre");
            }
            else if(balance < amount)
            {
                throw new ArgumentException("Amount kan ikke være mindre end balance på konto");
            }
            Contract.EndContractBlock();
            balance -= amount;
        }

        static void Main(string[] args)
        {
            Account acc = new Account();

            acc.Deposit(-1); 
            acc.Deposit(122); //Deposit bliver 121

            Console.WriteLine("Balance: " + acc.Balance.ToString());

            int read = Convert.ToInt32(Console.ReadLine());
            acc.Withdraw(read);

            Console.WriteLine("Balance nu: " + acc.Balance.ToString());

            Console.ReadKey();
        }

            
    }
}
