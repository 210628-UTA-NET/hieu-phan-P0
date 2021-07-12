using System;
using SSDModel;
using SSDBL;
using System.Collections.Generic;

namespace SSDUI
{
    public class StoreFrontsCustomerMenu : IMenu
    {
        private static List<Customers> listOfCustomers = new List<Customers>();
        private static List<Orders> listOfOrders = new List<Orders>();
        private ICustomerBL _customerBL;
        private IOrderBL _orderBL;
        public StoreFrontsCustomerMenu(ICustomerBL p_customerBL, IOrderBL p_orderBL)
        {
            _customerBL = p_customerBL;
            _orderBL = p_orderBL;
        }

        public void Menu()
        {
            System.Console.WriteLine("-----------------------------------------------------------------------");
            System.Console.WriteLine("Welcome To Store Front Customer Menu!!!");
            System.Console.WriteLine("What Would You Like To Do?");
            System.Console.WriteLine("[1] View All Customers");
            System.Console.WriteLine("[2] Search For Customers");
            System.Console.WriteLine("[3] View All Orders");
            System.Console.WriteLine("[4] Search For Orders");
            System.Console.WriteLine("[0] Store Front Menu");
        }

        public MenuType YourChoice()
        {
            string userChoice = Console.ReadLine();

            switch (userChoice)
            {
                case "1":
                    System.Console.WriteLine("-----------------------------------------------------------------------");
                    listOfCustomers = _customerBL.GetAllCustomers();
                    foreach (Customers c in listOfCustomers)
                    {
                        System.Console.WriteLine(c.ToString());
                    }
                    return MenuType.StoreFrontsCustomerMenu;
                case "2":
                    System.Console.WriteLine("-----------------------------------------------------------------------");
                    return MenuType.CustomersSearchMenu;
                case "3":
                    System.Console.WriteLine("-----------------------------------------------------------------------");
                    listOfOrders = _orderBL.GetAllOrders();
                    foreach (Orders o in listOfOrders)
                    {
                        System.Console.WriteLine(o.ToString());
                    }
                    return MenuType.StoreFrontsCustomerMenu;
                case "4":
                    return MenuType.StoreFrontsOrderSearchMenu;
                case "0":
                    return MenuType.StoreFrontsMenu;
                default:
                    Console.WriteLine("Input was not correct");
                    Console.WriteLine("Press Enter to continue");
                    Console.ReadLine();
                    return MenuType.StoreFrontsMenu;
            } 
        }
    }
}