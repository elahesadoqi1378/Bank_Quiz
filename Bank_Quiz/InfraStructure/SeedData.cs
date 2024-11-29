using Bank_Quiz.Contracts;
using Bank_Quiz.Entities;
using Bank_Quiz.Repositories;
using Bank_Quiz.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Quiz.InfraStructure
{
    //public class DataSeeder
    //{
    //    private readonly ICardRepository cardRepository;
    //    private readonly ITransactionRepository transactionRepository;

    //    public DataSeeder()
    //    {
    //        cardRepository = new CardRepository();
    //        transactionRepository = new TransactionRepository();
    //    }
    //    private void SeedِِData()
    //    {
    //        if (cardRepository.GetAll().Any())
    //        {
    //            return;
    //        }
    //    }
    //    public void SeedData()
    //    {

    //        var card1 = new Card
    //        {
    //            CardNumber = "1234567890123456",
    //            HolderName = "Elahe",
    //            Balance = 5000.0f,
    //            IsActive = true,
    //            Password = "1234",
    //            SourceTransactions = new List<Transaction>(),
    //            DestinationTransactions = new List<Transaction>()
    //        };

    //        var card2 = new Card
    //        {
    //            CardNumber = "9876543210987654",
    //            HolderName = "Amir",
    //            Balance = 10000.0f,
    //            IsActive = true,
    //            Password = "5678",
    //            SourceTransactions = new List<Transaction>(),
    //            DestinationTransactions = new List<Transaction>()
    //        };

    //        var card3 = new Card
    //        {
    //            CardNumber = "1111222233334444",
    //            HolderName = "Leila",
    //            Balance = 2000.0f,
    //            IsActive = true,
    //            Password = "9101",
    //            SourceTransactions = new List<Transaction>(),
    //            DestinationTransactions = new List<Transaction>()
    //        };


    //        cardRepository.Create(card1);
    //        cardRepository.Create(card2);
    //        cardRepository.Create(card3);


            //var transaction1 = new Transaction
            //{
            //    SourceCardNumber = "1234567890123456",
            //    DestinationCardNumber = "9876543210987654",
            //    Amount = 1000.0f,
            //    TransactionDate = DateTime.Now,
            //    isSuccessful = true,
            //    SourceCard = card1,
            //    DestinationCard = card2
            //};

            //var transaction2 = new Transaction
            //{
            //    SourceCardNumber = "9876543210987654",
            //    DestinationCardNumber = "1234567890123456",
            //    Amount = 500.0f,
            //    TransactionDate = DateTime.Now,
            //    isSuccessful = true,
            //    SourceCard = card2,
            //    DestinationCard = card1
            //};

            //var transaction3 = new Transaction
            //{
            //    SourceCardNumber = "1111222233334444",
            //    DestinationCardNumber = "1234567890123456",
            //    Amount = 100.0f,
            //    TransactionDate = DateTime.Now,
            //    isSuccessful = true,
            //    SourceCard = card3,
            //    DestinationCard = card1
            //};


            //transactionRepository.Create(transaction1);
            //transactionRepository.Create(transaction2);
            //transactionRepository.Create(transaction3);
        }
//    }

//}
