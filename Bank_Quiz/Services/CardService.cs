
using Bank_Quiz.Contracts;
using Bank_Quiz.Entities;
using Bank_Quiz.Repositories;

namespace Bank_Quiz.Services
{
    public class CardService
    {
        private readonly ICardRepository cardRepository;
        private readonly ITransactionRepository transactionRepository;
        //negahdari tedad talash namovafaq har kart
        private static Dictionary<string, int> failedLoginAttempts = new Dictionary<string, int>();
        public CardService()
        {
            cardRepository = cardRepository;
            transactionRepository = transactionRepository;
        }

        public Card GetCard(string cardNumber)
        {
            return cardRepository.Get(cardNumber);
        }

        public bool ValidateCardCredentials(string cardNumber, string password) //daryaft kart ba shomare kart
        {
            var card = cardRepository.Get(cardNumber);
            if (card?.Password == password)
            {
                
                if (failedLoginAttempts.ContainsKey(cardNumber))
                {
                    failedLoginAttempts.Remove(cardNumber);
                }
                return true;
            }
            else
            {
                if (failedLoginAttempts.ContainsKey(cardNumber))
                {
                    failedLoginAttempts[cardNumber]++;
                }
                else
                {
                    failedLoginAttempts[cardNumber] = 1;
                }

                
                if (failedLoginAttempts[cardNumber] >= 3)
                {
                    BlockCard(cardNumber);
                    throw new Exception("Card is blocked due to 3 incorrect password attempts.");
                }

                return false;
            }
        }

        public void BlockCard(string cardNumber)
        {
            var card = cardRepository.Get(cardNumber);
            if (card != null)
            {
                card.IsActive = false;
                cardRepository.Update(cardNumber, card);
            }
        }
        //metode enteqal vajh
        public void TransferFunds(string sourceCardNumber, string destinationCardNumber, float amount, string password)
        {
            
            if (!ValidateCardCredentials(sourceCardNumber, password))
            {
                throw new Exception("Invalid password.");
            }

            
            var sourceCard = cardRepository.Get(sourceCardNumber);
            var destinationCard = cardRepository.Get(destinationCardNumber);

           
            if (sourceCard == null || destinationCard == null)
            {
                throw new Exception("Invalid card numbers.");
            }
            if (!sourceCard.IsActive || !destinationCard.IsActive)
            {
                throw new Exception("One or both cards are inactive.");
            }

            if (sourceCard.Balance < amount)
            {
                throw new Exception("Insufficient balance.");
            }

           
            sourceCard.Balance -= amount;
            destinationCard.Balance += amount;

            
            cardRepository.Update(sourceCardNumber, sourceCard);
            cardRepository.Update(destinationCardNumber, destinationCard);

           
            var transaction = new Transaction
            {
                SourceCardNumber = sourceCardNumber,
                DestinationCardNumber = destinationCardNumber,
                Amount = amount,
                TransactionDate = DateTime.Now,
                isSuccessful = true
            };

            transactionRepository.Create(transaction);
        }

        public List<Transaction> GetTransactions(string cardNumber)
        {
            if (!IsValidCardNumber(cardNumber))
            {
                throw new Exception("Invalid card number. Card number must be 16 digits.");
            }


            var sourceTransactions = transactionRepository.GetAll().Where(t => t.SourceCardNumber == cardNumber).ToList();
            var destinationTransactions = transactionRepository.GetAll().Where(t => t.DestinationCardNumber == cardNumber).ToList();
            return sourceTransactions.Concat(destinationTransactions).ToList();
        }

        public bool AuthenticateUser(string cardNumber, string password)
        {
            var card = cardRepository.Get(cardNumber);
            if (card == null || !card.IsActive)
            {
                throw new Exception("Card not found or blocked.");
            }

            
            if (card.Password == password)
            {
              
                return true;
            }

            return false;
        }
        public bool IsValidCardNumber(string cardNumber)
        {
            return cardNumber.Length == 16 && cardNumber.All(char.IsDigit);
        }
    }

}
