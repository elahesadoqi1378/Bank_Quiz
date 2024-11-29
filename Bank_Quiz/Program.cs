using System;
using System.Linq;
using System.Collections.Generic;
using Bank_Quiz.Contracts;
using Bank_Quiz.InfraStructure;
using Bank_Quiz.Repositories;
using Bank_Quiz.Services;

public class Program
{
    private static CardService cardService;
    private static ICardRepository cardRepository;
    private static ITransactionRepository transactionRepository;

    public static void Main(string[] args)
    {
        
        cardRepository = new CardRepository();
        transactionRepository = new TransactionRepository();
        cardService = new CardService();

        
        //var dataSeeder = new DataSeeder();
        //dataSeeder.SeedData();

       
        bool running = true;
        while (running)
        {
            Console.Clear();
            Console.WriteLine("************ Main Menu ************");
            Console.WriteLine("1. Login");
            Console.WriteLine("2. Transfer Funds");
            Console.WriteLine("3. View Transactions");
            Console.WriteLine("4. Exit");
            Console.Write("Please select an option: ");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Login();
                    break;
                case "2":
                    TransferMoney();
                    break;
                case "3":
                    ViewTransactions();
                    break;
                case "4":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

    private static void Login()
    {
        Console.Clear();
        Console.WriteLine("************ Login ************");
        Console.Write("Please enter your card number: ");
        string cardNumber = Console.ReadLine();

        
        if (!cardService.IsValidCardNumber(cardNumber))
        {
            Console.WriteLine("The card number entered is not valid. It must be 16 digits.");
            return;
        }

        Console.Write("Please enter your password: ");
        string password = Console.ReadLine();

        
        if (cardService.AuthenticateUser(cardNumber, password))
        {
            Console.WriteLine("Login successful.");
        }
        else
        {
            Console.WriteLine("Incorrect password.");
        }

        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

    private static void TransferMoney()
    {
        Console.Clear();
        Console.WriteLine("************ Transfer Funds ************");

        Console.Write("Enter source card number: ");
        string sourceCardNumber = Console.ReadLine();

        if (!cardService.IsValidCardNumber(sourceCardNumber))
        {
            Console.WriteLine("The card number entered is not valid. It must be 16 digits.");
            return;
        }

        Console.Write("Enter destination card number: ");
        string destinationCardNumber = Console.ReadLine();

        if (!cardService.IsValidCardNumber(destinationCardNumber))
        {
            Console.WriteLine("The destination card number entered is not valid. It must be 16 digits.");
            return;
        }

        Console.Write("Enter the transfer amount: ");
        if (!float.TryParse(Console.ReadLine(), out float amount) || amount <= 0)
        {
            Console.WriteLine("The transfer amount must be a positive number.");
            return;
        }

        Console.Write("Please enter the source card password: ");
        string password = Console.ReadLine();

        try
        {
            cardService.TransferFunds(sourceCardNumber, destinationCardNumber, amount, password);
            Console.WriteLine("Funds transferred successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }

        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

    private static void ViewTransactions()
    {
        Console.Clear();
        Console.WriteLine("************ View Transactions ************");

        Console.Write("Please enter your card number: ");
        string cardNumber = Console.ReadLine();

        if (!cardService.IsValidCardNumber(cardNumber))
        {
            Console.WriteLine("The card number entered is not valid. It must be 16 digits.");
            return;
        }

        try
        {
            var transactions = cardService.GetTransactions(cardNumber);
            if (transactions.Any())
            {
                foreach (var transaction in transactions)
                {
                    Console.WriteLine($"Transaction: {transaction.TransactionId}, Amount: {transaction.Amount}, Date: {transaction.TransactionDate}, Success: {transaction.isSuccessful}");
                }
            }
            else
            {
                Console.WriteLine("No transactions found.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }

        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }
}
