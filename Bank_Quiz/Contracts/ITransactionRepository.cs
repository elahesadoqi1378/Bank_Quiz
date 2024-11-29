using Bank_Quiz.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Bank_Quiz.Contracts
{
    public interface ITransactionRepository
    {
        void Create(Transaction transaction);
        List<Transaction> GetAll();
        void Update(int id, Transaction t);
        void Delete(int id);
        Transaction Get(int id);
    }
}
