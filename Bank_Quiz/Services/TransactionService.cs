using Bank_Quiz.Contracts;
using Bank_Quiz.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Quiz.Services
{
    
        public class TransactionService
        {
            private readonly ITransactionRepository transactionRepository;

            public TransactionService()
            {
                transactionRepository = transactionRepository;
            }

            public List<Transaction> GetTransactionsForCard(string cardNumber)
            {
                return transactionRepository.GetAll()
                    .Where(t => t.SourceCardNumber == cardNumber || t.DestinationCardNumber == cardNumber)
                    .ToList();
            }

            public void RecordTransaction(Transaction transaction)
            {
                transactionRepository.Create(transaction);
            }
        }


}
