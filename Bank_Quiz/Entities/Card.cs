

using System.ComponentModel.DataAnnotations;

namespace Bank_Quiz.Entities
{
    public class Card
    {
        [Key]
        public string CardNumber { get; set; }
        public String HolderName { get; set; }
        public float Balance { get; set; }
        public bool IsActive { get; set; } = false;
        public string Password { get; set; }
        public List<Transaction> SourceTransactions { get; set; }
        public List<Transaction> DestinationTransactions { get; set; }
    }
}
