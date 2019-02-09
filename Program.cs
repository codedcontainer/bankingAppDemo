using System;
using banking;
using System.Collections.Generic;
using System.Linq;

namespace bankingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            bank bank = new bank();
            bank.accounts = new List<accountee>(){
                new accountee()
                {
                    name = "Alice",
                    checking = new Checking(1000.00),
                    savings = new Savings(5000)
                },
                new accountee()
                {
                    name = "Bob",
                    checking = new Checking(500.00),
                    savings = new Savings(2000.00)
                },
                new accountee()
            {
                name = "Eve",
                checking = new Checking(5000)
            }
            };

            accountee alice = (from account in bank.accounts
                               where account.name == "Alice"
                               select account).First();

            alice.checking.withdrawal(500.00);
            alice.checking.deposit(2000.00);
            alice.checking.accountTransfer(1500.00, ref alice, "savings");
            alice.savings.setInterest(12);

            accountee bob = (from account in bank.accounts
                             where account.name == "Bob"
                             select account).First();

            bob.checking.deposit(1500);
            bob.savings.withdrawal(1000);
            bob.savings.setInterest(12);

            accountee eve = (from account in bank.accounts
                             where account.name == "Eve"
                             select account).First();

            eve.checking.deposit(2000);
            eve.checking.withdrawal(1000);

            foreach (var account in bank.accounts)
            {

                Console.WriteLine(
                    "Account Owner - {0} \t\n Savings Amount - {1} \t\n Checking Amount - {2}",
                    account.name,
                    account.savings != null ? account.savings.getBalance() : 0,
                    account.checking != null ? account.checking.getBalance() : 0
                );
            }

        }
    }
}
