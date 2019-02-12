using System.Collections.Generic;

namespace banking
{
     class Account
    {
        double maxWithdrawal = 500.00; 
        double interest = .001;
        double transferFee = .01; 
        private double accountBalance {get;set;}
        public double getBalance(){
            return this.accountBalance; 
        }
        public void setBalance(double amount){
            this.accountBalance = amount; 
        }
        public void withdrawal(double amount){
            if (!( amount > maxWithdrawal) ){
                this.accountBalance -= amount;
            }
        }
        public void deposit(double amount){
            this.accountBalance += amount;
        }
        public void setInterest(int multiplyer){
            this.accountBalance += this.accountBalance * ( this.interest * multiplyer);
        }
        public void accountTransfer(double amount, ref accountee accountHolder, string accountType){
            this.accountBalance -= amount;
            this.accountBalance -= this.accountBalance * this.transferFee; 
            if (accountType == "savings"){
                accountHolder.savings.accountBalance += amount; 
            }
            else{
                accountHolder.checking.accountBalance += amount; 
            }
        }

    }
    class Checking: Account{
        public Checking(double initAmount){
            this.setBalance(initAmount); 
        }
    }
    class Savings: Account{
        public Savings(double initAmount){
            this.setBalance(initAmount);
        }
    }

    class bank{
        public List<accountee> accounts {get; set; }
    }
    class accountee{
       public string name {get; set;}
       public Savings savings {get; set;}
       public Checking checking {get; set;}
    }
}