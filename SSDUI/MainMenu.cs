using System;
namespace SSDUI
{
    public class MainMenu : IMenu
    {
        public void Menu()
        {
            System.Console.WriteLine("----------------------------------------");
            System.Console.WriteLine("Welcome to MainMenu!");
            System.Console.WriteLine("What would you like to do?");
            System.Console.WriteLine("[2] Print List of Customers");
            System.Console.WriteLine("[1] Customers Menu");
            System.Console.WriteLine("[0] Exit");
        }

        public string YourChoice()
        {
            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "0":
                    return "Exit";
                case "1":
                    return "CustomersMenu";
                case "2":
                    return "PrintListOfCustomer";
                default:
                    return "Unknown";
            }
        }
    }   
} 