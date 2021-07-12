using System;
using SSDModel;
using SSDBL;
using System.Collections.Generic;

namespace SSDUI
{
    public class StoreFrontsOrderSearchMenu : IMenu
    {
        private static List<Orders> listOfSearchedOrders = new List<Orders>();
        private string criteria;
        private string value;
        private IOrderBL _orderBL;
        public StoreFrontsOrderSearchMenu(IOrderBL p_orderBL)
        {
            _orderBL = p_orderBL;
        }
        public void Menu()
        {
            System.Console.WriteLine("-----------------------------------------------------------------------");
            System.Console.WriteLine("Welcome to Store Front Order Searching Menu!!!");
            System.Console.WriteLine("Please pick a searching criteria");
            System.Console.WriteLine("[1] Order ID");
            System.Console.WriteLine("[2] Customer ID");
            System.Console.WriteLine("[3] StoreFront ID");
            System.Console.WriteLine("[0] StoreFront Customer Menu");
        }

        public MenuType YourChoice()
        {
            string userChoice = Console.ReadLine();
            switch (userChoice)
            {
                case "1":
                    criteria = "id";
                    System.Console.WriteLine("Enter Order Id:");
                    SearchAndDisplayOrder(criteria);
                    return MenuType.StoreFrontsOrderSearchMenu;
                case "2":
                    criteria = "customerID";
                    System.Console.WriteLine("Enter Customer Id:");
                    SearchAndDisplayOrder(criteria);
                    return MenuType.StoreFrontsOrderSearchMenu;
                case "3":
                    criteria = "storeFrontID";
                    System.Console.WriteLine("Enter StoreFront Id:");
                    SearchAndDisplayOrder(criteria);
                    return MenuType.StoreFrontsOrderSearchMenu;
                case "0":
                    return MenuType.StoreFrontsCustomerMenu;
                default:
                    Console.WriteLine("Input was not correct");
                    Console.WriteLine("Press Enter to continue");
                    Console.ReadLine();
                    return MenuType.MainMenu;
            }
        }


        public void SearchAndDisplayOrder(string p_criteria)
        {
            bool repeat = true;
            while(repeat)
            {
                try
                {
                    value = Console.ReadLine();
                    listOfSearchedOrders = _orderBL.SearchOrders(criteria, value);
                    if (listOfSearchedOrders.Count == 0)
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
                        foreach(Orders o in listOfSearchedOrders)
                        {
                            System.Console.WriteLine(o.ToString());
                        }
                        repeat = false;
                    }
                }
                catch(System.Exception)
                {
                    System.Console.WriteLine("Input Was Not Valid");
                    System.Console.WriteLine("Order Not Found");
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