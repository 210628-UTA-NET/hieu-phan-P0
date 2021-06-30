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

        public string YourChoice()
        {
            string userChoice = Console.ReadLine();

            switch (userChoice)
            {
                case "0":
                    return "MainMenu";
                case "1":
                    return "CustomersInfo";
                default:
                    return "Unknown";
            } 
            
        }
    }
}