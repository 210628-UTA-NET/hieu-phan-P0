using System;

namespace SSDUI
{
    public class CustomersMenu : IMenu
    {
        public void Menu()
        {
            System.Console.WriteLine("----------------------------------------");
            System.Console.WriteLine("Welcome to Customer Menu!");
            System.Console.WriteLine("What would you like to do?");
            System.Console.WriteLine("[1] Customer Registration");
            System.Console.WriteLine("[0] Main Menu");
        }

        public MenuType YourChoice()
        {
            string userChoice = Console.ReadLine();

            switch (userChoice)
            {
                case "0":
                    return MenuType.MainMenu;
                case "1":
                    return MenuType.CustomersInfo;
                default:
                    Console.WriteLine("Input was not correct");
                    Console.WriteLine("Press Enter to continue");
                    Console.ReadLine();
                    return MenuType.CustomersMenu;
            } 
            
        }
    }
}