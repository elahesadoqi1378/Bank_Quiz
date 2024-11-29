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
    public class CardRepository : ICardRepository
    {
        private readonly AppDBContext appDBContext;

        public CardRepository()
        {
            appDBContext = new AppDBContext();
        }
        public void Create(Card card)
        {
            appDBContext.Cards.Add(card);
            appDBContext.SaveChanges();
        }
        public List<Card> GetAll()
        {
            var cards = appDBContext.Cards.ToList();
            return cards;
        }
        public void Update(string cardNumber, Card card)
        {
            var cardToEdit = appDBContext.Cards.FirstOrDefault(c => c.CardNumber == cardNumber);
            cardToEdit.Balance = card.Balance;
            appDBContext.SaveChanges();
        }
        public void Delete(string cardNumber)
        {
            var card = Get(cardNumber);
            if (card != null)
            {
                appDBContext.Cards.Remove(card);
                appDBContext.SaveChanges();
            }
            else
            {
                throw new Exception("can not find card with id " + card.CardNumber);
            }
        }
        public Card Get(string cardNumber)
        {
            var card = appDBContext.Cards.FirstOrDefault(c => c.CardNumber == cardNumber);
            if (card != null)
            {
                return card;
            }
            else
            {
                throw new Exception("can not find card with id " + card.CardNumber);
            }

        }

    }
}


