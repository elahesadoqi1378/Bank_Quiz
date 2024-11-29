

using Bank_Quiz.Entities;

namespace Bank_Quiz.Contracts
{
    public interface ICardRepository
    {
        void Create(Card carrd);
        List<Card> GetAll();
        void Update(string cardNumber, Card card);
        void Delete(string cardNumber);
        Card Get(string cardNumber);
    }
}
