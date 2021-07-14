using System;
using System.Collections.Generic;
using SSDModel;
using SSDBL;
namespace SSDUI 
{
    public class StoreFrontsMenu : IMenu
    {
        private static List<StoreFronts> ListOfAllStoreFronts;
        private IStoreFrontBL _sfBL;

        public StoreFrontsMenu(IStoreFrontBL p_sfBL)
        {
            _sfBL = p_sfBL;
        }
        
        public void Menu()
        {
            System.Console.Clear();
            System.Console.WriteLine("-----------------------------------------------------------------------");
            System.Console.WriteLine("Welcome to StoreFront Menu!");
            System.Console.WriteLine("What would you like to do?");
            System.Console.WriteLine("[1] View All Store Fronts");
            System.Console.WriteLine("[2] Search For Store Fronts");
            System.Console.WriteLine("[3] Inventory Menu");
            System.Console.WriteLine("[4] Customer Menu");
            System.Console.WriteLine("[0] Main Menu");
            System.Console.WriteLine("-----------------------------------------------------------------------");
        }

        public MenuType YourChoice()
        {
            System.Console.Write("Enter Your Choice: ");
            string userChoice = Console.ReadLine();

            switch (userChoice)
            {
                case "1":
                    System.Console.Clear();
                    System.Console.WriteLine("-----------------------------------------------------------------------");
                    ListOfAllStoreFronts = _sfBL.GetAllStoreFronts();
                    foreach (StoreFronts sf in ListOfAllStoreFronts)
                    {
                        System.Console.WriteLine(sf.ToString());
                    }
                    System.Console.WriteLine("-----------------------------------------------------------------------");
                    System.Console.Write("Enter To Continue");
                    System.Console.ReadLine();
                    return MenuType.StoreFrontsMenu;
                case "2":
                    return MenuType.StoreFrontsSearchMenu;
                case "3":
                    return MenuType.StoreFrontsInventoryMenu;
                case "4":
                    return MenuType.StoreFrontsCustomerMenu;
                case "0":
                    return MenuType.MainMenu;
                default:
                    Console.WriteLine("Input was not correct");
                    Console.WriteLine("Press Enter to continue");
                    Console.ReadLine();
                    return MenuType.StoreFrontsMenu;
            } 
        }
    }
}