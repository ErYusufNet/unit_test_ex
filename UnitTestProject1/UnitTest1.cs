using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AddTransaction_InsufficientBalance_ReturnsFalse()
        {
            // Arrange
            Bank bank = new Bank();
            Account from = new Account(100111);
            Account to = new Account(100222);
            double transactionValue = 200;

            // Act
            bool result = bank.AddTransaction(to, from, transactionValue);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void AddTransaction_SufficientBalance_TransfersCorrectly()
        {
            // Arrange
            Bank bank = new Bank();
            Account from = new Account(100333);
            Account to = new Account(100444);
            from.Transaction(300); // Set initial balance
            double transactionValue = 200;

            // Act
            bool result = bank.AddTransaction(to, from, transactionValue);

            // Assert
            Assert.IsTrue(result);
            Assert.AreEqual(100, from.Balance); // Remaining balance after transaction
        }

        [TestMethod]
        public void AddTransaction_InvalidAccounts_ReturnsFalse()
        {
            // Arrange
            Bank bank = new Bank();
            Account from = null; // Invalid "from" account
            Account to = new Account(100555);
            double transactionValue = 200;

            // Act
            bool result = bank.AddTransaction(to, from, transactionValue);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void AddTransaction_SameAccount_ReturnsFalse()
        {
            // Arrange
            Bank bank = new Bank();
            Account from = new Account(100666);
            Account to = from; // Same account
            double transactionValue = 200;

            // Act
            bool result = bank.AddTransaction(to, from, transactionValue);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void AddTransaction_NegativeTransactionValue_ReturnsFalse()
        {
            // Arrange
            Bank bank = new Bank();
            Account from = new Account(100777);
            Account to = new Account(100888);
            double transactionValue = -200; // Negative transaction value

            // Act
            bool result = bank.AddTransaction(to, from, transactionValue);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void AddTransaction_NonexistentToAccount_ReturnsFalse()
        {
            // Arrange
            Bank bank = new Bank();
            Account from = new Account(100999);
            Account to = null; // Nonexistent "to" account
            double transactionValue = 200;

            // Act
            bool result = bank.AddTransaction(to, from, transactionValue);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void AddTransaction_NullFromAccount_ReturnsFalse()
        {
            // Arrange
            Bank bank = new Bank();
            Account from = null; // Null "from" account
            Account to = new Account(101010);
            double transactionValue = 200;

            // Act
            bool result = bank.AddTransaction(to, from, transactionValue);

            // Assert
            Assert.IsFalse(result);
        }
    }
}
