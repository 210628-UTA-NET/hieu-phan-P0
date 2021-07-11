using System;
using System.Collections.Generic;
using SSDModel;
using SSDBL;
namespace SSDUI
{
    public class CustomersViewStoreMenu : IMenu
    {
        private List<StoreFronts> _listOfSearchedStore = new List<StoreFronts>();
        private IStoreFrontBL _sfbl;
        public CustomersViewStoreMenu(IStoreFrontBL p_sfbl)
        {
            _sfbl = p_sfbl;
        }
        public void Menu()
        {
            System.Console.WriteLine("-----------------------------------------------------------------------");
            System.Console.WriteLine("Welcome To Store Searching Menu!!!");
            System.Console.WriteLine("What would you like to do?");
            System.Console.WriteLine("[1]View All Stores");
            System.Console.WriteLine("[2]Search For A Store");
            System.Console.WriteLine("[0]Customer Menu");
        }

        public MenuType YourChoice()
        {
            string userChoice = Console.ReadLine();

            switch (userChoice)
            {
                case "0":
                    return MenuType.CustomersMenu;
                case "1":
                    _listOfSearchedStore = _sfbl.GetAllStoreFronts();
                    System.Console.WriteLine("-----------------------------------------------------------------------");
                    System.Console.WriteLine("List of Store Fronts:");
                    foreach(StoreFronts sf in _listOfSearchedStore)
                    {
                        System.Console.WriteLine("-----------------------------------------------------------------------");
                        System.Console.WriteLine(sf.ToString());
                    }
                    System.Console.WriteLine("-----------------------------------------------------------------------");
                    _listOfSearchedStore.Clear();
                    return MenuType.CustomersViewStoreMenu;
                case "2":
                    return MenuType.StoreFrontsSearchMenu;
                default:
                    Console.WriteLine("Input was not correct");
                    Console.WriteLine("Press Enter to continue");
                    Console.ReadLine();
                    return MenuType.CustomersMenu;
            } 
        }
    }
}