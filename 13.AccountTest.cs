/*
13. Account Test [Test case design] [Unit testing]

Using only NUnitLite 1's Assert.AreEqual method, write tests for the Account class that cover the following cases:

    The Deposit and Withdraw methods will not accept negative numbers.
    Account cannot overstep its overdraft limit.
    The Deposit and Withdraw methods will deposit or withdraw the correct amount, respectively.
    The Withdraw and Deposit methods return the correct results.

https://www.testdome.com/d/c-sharp-interview-questions/18

public class Account
{
    public double Balance { get; private set; }
    public double OverdraftLimit { get; private set; }

    public Account(double overdraftLimit)
    {
        this.OverdraftLimit = overdraftLimit > 0 ? overdraftLimit : 0;
        this.Balance = 0;
    }

    public bool Deposit(double amount)
    {
        if (amount >= 0)
        {
            this.Balance += amount;
            return true;
        }
        return false;
    }

    public bool Withdraw(double amount)
    {
        if (this.Balance - amount >= -this.OverdraftLimit && amount >= 0)
        {
            this.Balance -= amount;
            return true;
        }
        return false;
    }
}

using System;
using NUnit.Framework;

[TestFixture]
public class Tester
{	
    private double epsilon = 1e-6;

    [Test]
    public void AccountCannotHaveNegativeOverdraftLimit()
    {
        Account account = new Account(-20);
        
        Assert.AreEqual(0, account.OverdraftLimit, epsilon);
    }
}
*/ 

// =============================================================== solution (passes 4/4 tests)

using System;
using NUnit.Framework;

[TestFixture]
public class Tester
{	
    private double epsilon = 1e-6;

    [Test]
    public void AccountCannotHaveNegativeOverdraftLimit()
    {
        Account account = new Account(-20);
    
        Assert.AreEqual(0, account.OverdraftLimit, epsilon);
    }

        [Test]
        public void DepositCannotAcceptNegativeNumbers() {
            Account account = new Account(20);
            account.Deposit(-1.0);
            Assert.AreEqual(0, account.Balance, epsilon);     
        }

        [Test]
        public void WithdrawCannotAcceptNegativeNumbers() {
            Account account = new Account(20);
            account.Withdraw(-1.0);
            Assert.AreEqual(0, account.Balance, epsilon);   
        }

        [Test]
        public void AccountCannotOverStepOverdraftLimit()
        {
            Account account = new Account(20);
            account.Deposit(10);
            account.Withdraw(100);
            Assert.AreEqual(10, account.Balance, epsilon);        
        }

        [Test]
        public void DepositDepositsTheCorrectAmount() {
            Account account = new Account(20);
            account.Deposit(1);
            Assert.AreEqual(1, account.Balance, epsilon);   
        }
    
        [Test]
        public void WithdrawWithdrawsTheCorrectAmount() {
            Account account = new Account(20);
            account.Withdraw(1);
            Assert.AreEqual(-1, account.Balance, epsilon);   
        }
    
        [Test]
        public void DepositReturnTrue() {
            Account account = new Account(20);
            bool result = account.Deposit(1.0);
            Assert.AreEqual(true, result);    //Assert.IsTrue(result); 
        }
        
        [Test]
        public void WithdrawReturnTrue() {
            Account account = new Account(20);
            bool result = account.Withdraw(1.0);
            Assert.AreEqual(true, result);    //Assert.IsTrue(result); 
        }
    
        [Test]
        public void DepositReturnFalse() {
            Account account = new Account(20);
            bool result = account.Deposit(-1.0);
            Assert.AreEqual(false, result);    //Assert.IsFalse(result); 
        }
        
        [Test]
        public void WithdrawReturnFalse() {
            Account account = new Account(20);
            bool result = account.Withdraw(-1.0);
            Assert.AreEqual(false, result);    //Assert.IsFalse(result); 
        }        
}