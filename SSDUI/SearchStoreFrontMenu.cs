using System;
using SSDModel;
using SSDBL;
using System.Collections.Generic;

namespace SSDUI
{
    public class SearchStoreFrontMenu : IMenu
    {
        private static List<StoreFronts> listOfSearchStoreFront;
        private string criteria;
        private string value;
        private IStoreFrontBL _sfbl;
        public SearchStoreFrontMenu(IStoreFrontBL p_sfbl)
        {
            _sfbl = p_sfbl;
        }
        public void Menu()
        {
            System.Console.WriteLine("Welcome to Store Front Searching Menu!!!");
            System.Console.WriteLine("Please pick a searching criteria");
            System.Console.WriteLine("[3] Using Address");
            System.Console.WriteLine("[2] Using Name");
            System.Console.WriteLine("[1] StoreFronts Menu");
            System.Console.WriteLine("[0] Main Menu");
        }

        public MenuType YourChoice()
        {
            string userChoice = Console.ReadLine();
            switch (userChoice)
            {
                case "3":
                    criteria = "address";
                    System.Console.WriteLine("Enter StoreFront Address:");
                    value = System.Console.ReadLine();
                    listOfSearchStoreFront = _sfbl.SearchStoreFronts(criteria, value);
                    if (listOfSearchStoreFront == null)
                    {
                        System.Console.WriteLine("There is no matching result.");
                    }
                    else
                    {
                        for (int i = 0; i < listOfSearchStoreFront.Count; i++)
                        {
                            System.Console.WriteLine("[{A}] {B}",i,listOfSearchStoreFront[i].ToString());
                        }

                        System.Console.WriteLine("Here Is The Store Front's Inventory: ");
                        foreach (Products p in listOfSearchStoreFront[0].Inventory)
                        {
                            System.Console.WriteLine(p.ToString());
                        }
                    }
                    return MenuType.SearchStoreFrontMenu;
                case "2":
                    criteria = "name";
                    System.Console.WriteLine("Enter StoreFront Name:");
                    value = System.Console.ReadLine();
                    listOfSearchStoreFront = _sfbl.SearchStoreFronts(criteria, value);
                    if (listOfSearchStoreFront == null)
                    {
                        System.Console.WriteLine("There is no matching result.");
                    }
                    else
                    {
                        for (int i = 0; i < listOfSearchStoreFront.Count; i++)
                        {
                            System.Console.WriteLine("[{A}] {B}",i,listOfSearchStoreFront[i].ToString());
                        }
                        System.Console.WriteLine("Pick The Store Front Using Its Index (From 0-{A}) To See Its Inventory: ", listOfSearchStoreFront.Count-1);
                        string index = Console.ReadLine();
                        try
                        {
                            foreach (Products p in listOfSearchStoreFront[int.Parse(index)].Inventory)
                            {
                                System.Console.WriteLine(p.ToString());
                            }
                        }
                        catch (System.Exception)
                        {
                            System.Console.WriteLine("Something Wrong");
                        }                        
                    }
                    return MenuType.SearchStoreFrontMenu;
                case "1":
                    return MenuType.StoreFrontsMenu;
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