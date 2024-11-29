using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Bank_Quiz.Entities
{
    public class Transaction
    {
        [Key]
        public int TransactionId { get; set; }
        public string SourceCardNumber { get; set; }
        public string DestinationCardNumber { get; set; }
        public float Amount { get; set; }
        public DateTime TransactionDate { get; set; }
        public bool isSuccessful { get; set; } = false;
        public Card SourceCard { get; set; }

        public Card DestinationCard { get; set; }

    }
}
