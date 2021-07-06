using System;

namespace SSDUI 
{
    public class StoreFrontsMenu : IMenu
    {
        public void Menu()
        {
            System.Console.WriteLine("----------------------------------------");
            System.Console.WriteLine("Welcome to StoreFront Menu!");
            System.Console.WriteLine("What would you like to do?");
            System.Console.WriteLine("[0] Main Menu");
            System.Console.WriteLine("[1] Search StoreFront");
        }

        public MenuType YourChoice()
        {
            string userChoice = Console.ReadLine();

            switch (userChoice)
            {
                case "0":
                    return MenuType.MainMenu;
                case "1":
                    return MenuType.SearchStoreFrontMenu;
                default:
                    Console.WriteLine("Input was not correct");
                    Console.WriteLine("Press Enter to continue");
                    Console.ReadLine();
                    return MenuType.CustomersMenu;
            } 
            
        }
    }
}