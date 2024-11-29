using Bank_Quiz.Contracts;
using Bank_Quiz.Entities;
using Bank_Quiz.InfraStructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Quiz.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly AppDBContext appDBContext;

        public TransactionRepository()
        {
            appDBContext = new AppDBContext();
        }
        public void Create(Transaction transaction)
        {

            appDBContext.Transactions.Add(transaction);
            appDBContext.SaveChanges();
        }
        public List<Transaction> GetAll()
        {
            var transactions = appDBContext.Transactions.ToList();
            return transactions;

        }
        public void Update(int id, Transaction t)
        {
            var transactionToEdit = appDBContext.Transactions.FirstOrDefault(t => t.TransactionId == id);
            transactionToEdit.Amount = t.Amount;
            appDBContext.SaveChanges();
        }
        public void Delete(int id)
        {
            var transaction = Get(id);
            if (transaction != null)
            {
                appDBContext.Transactions.Remove(transaction);
                appDBContext.SaveChanges();
            }
            else
            {
                throw new Exception("can not find transaction with id " + transaction.TransactionId);
            }
        }
        public Transaction Get(int id)
        {
            var transaction = appDBContext.Transactions.FirstOrDefault(t => t.TransactionId == id);
            if (transaction != null)
            {
                return transaction;
            }
            else
            {
                throw new Exception("can not find transaction with id " + transaction.TransactionId);
            }

        }

    }
}
