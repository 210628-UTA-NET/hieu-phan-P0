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
            // System.Console.WriteLine("[2] Print List of Customers");
            System.Console.WriteLine("[0] Exit");
            System.Console.WriteLine("[1] Customers Menu");
        }

        public MenuType YourChoice()
        {
            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "0":
                    return MenuType.Exit;
                case "1":
                    return MenuType.CustomersMenu;
                // case "2":
                //     return MenuType.PrintListOfCustomer;
                default:
                    Console.WriteLine("Input was not correct");
                    Console.WriteLine("Press Enter to continue");
                    Console.ReadLine();
                    return MenuType.MainMenu;
            }
        }
    }   
} 