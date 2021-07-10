using System;

namespace SSDUI
{
    public class CustomersMenu : IMenu
    {
        public void Menu()
        {
            System.Console.WriteLine("-----------------------------------------------------------------------");
            System.Console.WriteLine("Welcome to Customer Menu!");
            System.Console.WriteLine("What would you like to do?");
            System.Console.WriteLine("[1] Log In");
            System.Console.WriteLine("[2] Register");
            System.Console.WriteLine("[3] View Stores");
            System.Console.WriteLine("[0] Main Menu");
        }

        public MenuType YourChoice()
        {
            string userChoice = Console.ReadLine();

            switch (userChoice)
            {
                case "1":
                    return MenuType.CustomersLogInMenu;
                case "2":
                    return MenuType.AddCustomerMenu;
                case "3":
                    return MenuType.CustomersViewStoreMenu;
                case "0":
                    return MenuType.MainMenu;
                default:
                    Console.WriteLine("Input was not correct");
                    Console.WriteLine("Press Enter to continue");
                    Console.ReadLine();
                    return MenuType.CustomersMenu;
            } 
            
        }
    }
}