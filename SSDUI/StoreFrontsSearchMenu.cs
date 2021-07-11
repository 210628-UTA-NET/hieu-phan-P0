using System;
using SSDModel;
using SSDBL;
using System.Collections.Generic;

namespace SSDUI
{
    public class StoreFrontsSearchMenu : IMenu
    {
        private static List<StoreFronts> ListOfSearchedStoreFront = new List<StoreFronts>();
        private string criteria;
        private string value;
        private IStoreFrontBL _sfBL;
        public StoreFrontsSearchMenu(IStoreFrontBL p_sfBL)
        {
            _sfBL = p_sfBL;
        }
        public void Menu()
        {
            System.Console.WriteLine("-----------------------------------------------------------------------");
            System.Console.WriteLine("Welcome to Store Front Searching Menu!!!");
            System.Console.WriteLine("Please pick a searching criteria");
            System.Console.WriteLine("[1] ID");
            System.Console.WriteLine("[2] Name");
            System.Console.WriteLine("[3] Address");
            System.Console.WriteLine("[4] City");
            System.Console.WriteLine("[5] State");
            System.Console.WriteLine("[0] Main Menu");
        }

        public MenuType YourChoice()
        {
            string userChoice = Console.ReadLine();
            switch (userChoice)
            {
                case "1":
                    criteria = "id";
                    System.Console.WriteLine("Enter Store Front Id:");
                    SearchAndDisplayStoreFront(criteria);
                    return MenuType.StoreFrontsSearchMenu;
                case "2":
                    criteria = "name";
                    System.Console.WriteLine("Enter Store Front Name:");
                    SearchAndDisplayStoreFront(criteria);
                    return MenuType.StoreFrontsSearchMenu;
                case "3":
                    criteria = "address";
                    System.Console.WriteLine("Enter StoreFront Address:");
                    SearchAndDisplayStoreFront(criteria);
                    return MenuType.StoreFrontsSearchMenu;
                case "4":
                    criteria = "city";
                    System.Console.WriteLine("Enter StoreFront City:");
                    SearchAndDisplayStoreFront(criteria);
                    return MenuType.StoreFrontsSearchMenu;
                case "5":
                    criteria = "state";
                    System.Console.WriteLine("Enter StoreFront State:");
                    SearchAndDisplayStoreFront(criteria);
                    return MenuType.StoreFrontsSearchMenu;
                case "0":
                    return MenuType.MainMenu;
                default:
                    Console.WriteLine("Input was not correct");
                    Console.WriteLine("Press Enter to continue");
                    Console.ReadLine();
                    return MenuType.MainMenu;
            }
        }


        public void SearchAndDisplayStoreFront(string p_criteria)
        {
            bool repeat = true;
            while(repeat)
            {
                try
                {
                    value = Console.ReadLine();
                    ListOfSearchedStoreFront = _sfBL.SearchStoreFronts(criteria, value);
                    if (ListOfSearchedStoreFront.Count == 0)
                    {
                        System.Console.WriteLine("No Results.");
                        System.Console.WriteLine("Enter To Continue or 'quit' To Quit");
                        string string0 = Console.ReadLine().ToLower();
                        switch(string0)
                        {
                            case "quit":
                            repeat = false;
                            break;
                            default:
                            System.Console.WriteLine("Re-enter Your " + p_criteria + " Search Value: ");
                            break;
                        }
                    }
                    else
                    {
                        System.Console.WriteLine("-----------------------------------------------------------------------");
                        System.Console.WriteLine("List of Results");
                        foreach(StoreFronts sf in ListOfSearchedStoreFront)
                        {
                            System.Console.WriteLine(sf.ToString());
                        }
                        repeat = false;
                    }
                }
                catch(System.Exception)
                {
                    System.Console.WriteLine("Input Was Not Valid");
                    System.Console.WriteLine("StoreFront Not Found");
                    System.Console.WriteLine("Enter To Continue or 'quit' To Quit");
                    string string0 = Console.ReadLine().ToLower();
                    switch(string0)
                    {
                        case "quit":
                        repeat = false;
                        break;
                        default:
                        System.Console.WriteLine("Re-enter Your " + p_criteria + " Search Value: ");
                        break;
                    }
                }
            }

        }
    }
}