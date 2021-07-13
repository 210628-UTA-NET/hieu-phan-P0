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
            System.Console.Clear();
            System.Console.WriteLine("-----------------------------------------------------------------------");
            System.Console.WriteLine("Welcome To Store Front Customer Menu!!!");
            System.Console.WriteLine("What Would You Like To Do?");
            System.Console.WriteLine("[1] Add A Customer");
            System.Console.WriteLine("[2] View All Customers");
            System.Console.WriteLine("[3] Search For Customers");
            System.Console.WriteLine("[4] View All Orders");
            System.Console.WriteLine("[5] Search For Orders");
            System.Console.WriteLine("[0] Go Back");
            System.Console.WriteLine("-----------------------------------------------------------------------");
        }

        public MenuType YourChoice()
        {
            System.Console.Write("Enter Your Choice: ");
            string userChoice = Console.ReadLine();

            switch (userChoice)
            {
                case "1":
                    return MenuType.AddCustomerMenu;
                case "2":
                    System.Console.Clear();
                    System.Console.WriteLine("-----------------------------------------------------------------------");
                    listOfCustomers = _customerBL.GetAllCustomers();
                    foreach (Customers c in listOfCustomers)
                    {
                        System.Console.WriteLine(c.ToString());
                    }
                    System.Console.WriteLine("-----------------------------------------------------------------------");
                    System.Console.Write("Enter To Continue");
                    System.Console.ReadLine();
                    return MenuType.StoreFrontsCustomerMenu;
                case "3":
                    System.Console.WriteLine("-----------------------------------------------------------------------");
                    return MenuType.CustomersSearchMenu;
                case "4":
                    System.Console.Clear();
                    System.Console.WriteLine("-----------------------------------------------------------------------");
                    listOfOrders = _orderBL.GetAllOrders();
                    foreach (Orders o in listOfOrders)
                    {
                        System.Console.WriteLine(o.ToString());
                    }
                    System.Console.WriteLine("-----------------------------------------------------------------------");
                    System.Console.Write("Enter To Continue");
                    System.Console.ReadLine();
                    return MenuType.StoreFrontsCustomerMenu;
                case "5":
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