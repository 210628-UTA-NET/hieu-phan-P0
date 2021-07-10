using System;
using SSDModel;
using SSDBL;
using System.Collections.Generic;

namespace SSDUI
{
    public class SearchStoreFrontMenu : IMenu
    {
        private static List<StoreFronts> ListOfSearchedStoreFront;
        private string criteria;
        private string value;
        private IStoreFrontBL _sfbl;
        public SearchStoreFrontMenu(IStoreFrontBL p_sfbl)
        {
            _sfbl = p_sfbl;
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
                    value = System.Console.ReadLine();
                    ListOfSearchedStoreFront = _sfbl.SearchStoreFronts(criteria, value);
                    DisplaySearchResult(ListOfSearchedStoreFront);
                    return MenuType.SearchStoreFrontMenu;
                case "2":
                    criteria = "name";
                    System.Console.WriteLine("Enter Store Front Name:");
                    value = System.Console.ReadLine();
                    ListOfSearchedStoreFront = _sfbl.SearchStoreFronts(criteria, value);
                    DisplaySearchResult(ListOfSearchedStoreFront);
                    return MenuType.SearchStoreFrontMenu;
                case "3":
                    criteria = "address";
                    System.Console.WriteLine("Enter StoreFront Address:");
                    value = System.Console.ReadLine();
                    ListOfSearchedStoreFront = _sfbl.SearchStoreFronts(criteria, value);
                    DisplaySearchResult(ListOfSearchedStoreFront);
                    return MenuType.SearchStoreFrontMenu;
                case "4":
                    criteria = "city";
                    System.Console.WriteLine("Enter StoreFront City:");
                    value = System.Console.ReadLine();
                    ListOfSearchedStoreFront = _sfbl.SearchStoreFronts(criteria, value);
                    DisplaySearchResult(ListOfSearchedStoreFront);
                    return MenuType.SearchStoreFrontMenu;
                case "5":
                    criteria = "state";
                    System.Console.WriteLine("Enter StoreFront State:");
                    value = System.Console.ReadLine();
                    ListOfSearchedStoreFront = _sfbl.SearchStoreFronts(criteria, value);
                    DisplaySearchResult(ListOfSearchedStoreFront);
                    return MenuType.SearchStoreFrontMenu;
                case "0":
                    return MenuType.MainMenu;
                default:
                    Console.WriteLine("Input was not correct");
                    Console.WriteLine("Press Enter to continue");
                    Console.ReadLine();
                    return MenuType.MainMenu;
            }
        }

        public void DisplaySearchResult(List<StoreFronts> p_list)
        {
            if (p_list.Count == 0)
            {
                System.Console.WriteLine("There is no matching result.");
            }
            else
            {
                System.Console.WriteLine("-----------------------------------------------------------------------");
                System.Console.WriteLine("List of Results");
                for (int i = 0; i < p_list.Count; i++)
                {
                    System.Console.WriteLine(p_list[i].ToString());
                }
                // System.Console.WriteLine("Pick The Store Front's Index To See Its Inventory or -99 For Store Front Menu");
                // string userChoiceIndex = Console.ReadLine();
                // while(userChoiceIndex != "-99")
                // {
                //     try
                //     {
                //         foreach (Products p in p_list[int.Parse(userChoiceIndex)].Inventory)
                //         {
                //             System.Console.WriteLine(p.ToString());
                //         }
                //         System.Console.WriteLine("Pick The Store Front's Index To See Its Inventory or -99 For Store Front Menu");
                //         userChoiceIndex = Console.ReadLine();
                //     }
                //     catch (System.Exception)
                //     {
                //         System.Console.WriteLine("Index Is Not Valid!!!");
                //         System.Console.WriteLine("Pick The Store Front's Index To See Its Inventory or -99 For Store Front Menu");
                //         userChoiceIndex = Console.ReadLine();
                //     }
                // }                       
            }
        }
    }
}