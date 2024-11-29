
using Bank_Quiz.Entities;
using Microsoft.EntityFrameworkCore;

using System.Collections.Generic;
using System.Reflection.Emit;

namespace Bank_Quiz.InfraStructure
{

    public class AppDBContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer
                ("Data Source =ELAMIR\\SQLEXPRESS; Database = Bank_Quiz; Integrated Security=True; User ID = sa; Password =123456 ; TrustServerCertificate=True");
            base.OnConfiguring(optionsBuilder);
        }
        public DbSet<Card> Cards { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Transaction>()
             .HasOne(t => t.SourceCard)
             .WithMany(c => c.SourceTransactions)
             .HasForeignKey(t => t.SourceCardNumber).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Transaction>()
             .HasOne(t => t.DestinationCard)
             .WithMany(c => c.DestinationTransactions)
             .HasForeignKey(t => t.DestinationCardNumber).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Transaction>()
                .HasKey(t => t.TransactionId);

            modelBuilder.Entity<Card>()
               .HasKey(c => c.CardNumber);
            


        }

    }

}
