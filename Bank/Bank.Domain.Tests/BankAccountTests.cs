using Bank.Domain;
using NUnit.Framework;
using System;

namespace Bank.Domain.Tests
{
    public class BankAccountTests
    {
        [Test]
        public void Debit_WithValidAmount_UpdatesBalance()
        {
            double beginningBalance = 11.99;
            double debitAmount = 4.55;
            double expected = 7.44;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

            account.Debit(debitAmount);

            double actual = account.Balance;
            Assert.AreEqual(expected, actual, 0.001);
        }

        [Test]
        public void Debit_WhenAmountIsLessThanZero_ShouldThrowArgumentOutOfRange()
        {
            double beginningBalance = 11.99;
            double debitAmount = -100.00;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => account.Debit(debitAmount));
            StringAssert.Contains(BankAccount.DebitAmountLessThanZeroMessage, ex.Message);
        }

        [Test]
        public void Debit_WhenAmountIsMoreThanBalance_ShouldThrowArgumentOutOfRange()
        {
            double beginningBalance = 11.99;
            double debitAmount = 20.0;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => account.Debit(debitAmount));
            StringAssert.Contains(BankAccount.DebitAmountExceedsBalanceMessage, ex.Message);
        }

        [Test]
        public void Credit_WithValidAmount_UpdatesBalance()
        {
            double beginningBalance = 11.99;
            double creditAmount = 5.00;
            double expected = 16.99;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

            account.Credit(creditAmount);

            double actual = account.Balance;
            Assert.AreEqual(expected, actual, 0.001);
        }

        [Test]
        public void Credit_WhenAmountIsLessThanZero_ShouldThrowArgumentOutOfRange()
        {
            double beginningBalance = 11.99;
            double creditAmount = -5.00;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => account.Credit(creditAmount));
            StringAssert.Contains(BankAccount.CreditAmountLessThanZeroMessage, ex.Message);
        }

        [Test]
        public void Constructor_SetsCustomerNameAndBalanceCorrectly()
        {
            string expectedName = "Mr. Bryan Walton";
            double expectedBalance = 11.99;
            BankAccount account = new BankAccount(expectedName, expectedBalance);

            Assert.AreEqual(expectedName, account.CustomerName);
            Assert.AreEqual(expectedBalance, account.Balance, 0.001);
        }
    }
}
