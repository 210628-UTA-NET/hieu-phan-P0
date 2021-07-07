using System;
using SSDModel;
using SSDBL;
using System.Collections.Generic;

namespace SSDUI
{
    public class SearchCustomerMenu : IMenu
    {
        private static List<Customers> listOfSearchedCustomer;
        private string criteria;
        private string value;
        private ICustomerBL _customerBL;

        public SearchCustomerMenu(ICustomerBL p_customerBL)
        {
            _customerBL = p_customerBL;
        }

        public void Menu()
        {
            System.Console.WriteLine("-------------------------------------");
            System.Console.WriteLine("Welcome to Customer Searching Menu!!!");
            System.Console.WriteLine("Please pick a searching criteria");
            System.Console.WriteLine("[6] Using Phone Number");
            System.Console.WriteLine("[5] Using Email");
            System.Console.WriteLine("[4] Using Address");
            System.Console.WriteLine("[3] Using Last Name");
            System.Console.WriteLine("[2] Using First Name");
            System.Console.WriteLine("[1] Customer Menu");
            System.Console.WriteLine("[0] Main Menu");
            System.Console.WriteLine("-------------------------------------");
        }

        public MenuType YourChoice()
        {
            string userChoice = Console.ReadLine();
            switch (userChoice)
            {
                case "6":
                    criteria = "phone";
                    System.Console.WriteLine("Enter customer phone number:");
                    value = System.Console.ReadLine();
                    listOfSearchedCustomer = _customerBL.SearchCustomer(criteria, value);
                    if (listOfSearchedCustomer == null)
                    {
                        System.Console.WriteLine("There is no matching result.");
                    }
                    else
                    {
                        foreach (Customers c in listOfSearchedCustomer)
                        {
                            System.Console.WriteLine(c.ToString());
                        }
                    }
                    return MenuType.SearchCustomerMenu;
                case "5":
                    criteria = "email";
                    System.Console.WriteLine("Enter customer email:");
                    value = System.Console.ReadLine();
                    listOfSearchedCustomer = _customerBL.SearchCustomer(criteria, value);
                    if (listOfSearchedCustomer == null)
                    {
                        System.Console.WriteLine("There is no matching result.");
                    }
                    else
                    {
                        foreach (Customers c in listOfSearchedCustomer)
                        {
                            System.Console.WriteLine(c.ToString());
                        }                     
                    }
                    return MenuType.SearchCustomerMenu;
                case "4":
                    criteria = "address";
                    System.Console.WriteLine("Enter customer address:");
                    value = System.Console.ReadLine();
                    listOfSearchedCustomer = _customerBL.SearchCustomer(criteria, value);
                    if (listOfSearchedCustomer == null)
                    {
                        System.Console.WriteLine("There is no matching result.");
                    }
                    else
                    {
                        foreach (Customers c in listOfSearchedCustomer)
                        {
                            System.Console.WriteLine(c.ToString());
                        }
                    }
                    return MenuType.SearchCustomerMenu;
                case "3":
                    criteria = "lname";
                    System.Console.WriteLine("Enter customer last name:");
                    value = System.Console.ReadLine();
                    listOfSearchedCustomer = _customerBL.SearchCustomer(criteria, value);
                    if (listOfSearchedCustomer == null)
                    {
                        System.Console.WriteLine("There is no matching result.");
                    }
                    else
                    {
                        foreach (Customers c in listOfSearchedCustomer)
                        {
                            System.Console.WriteLine(c.ToString());
                        }
                    }
                    return MenuType.SearchCustomerMenu;
                case "2":
                    criteria = "fname";
                    System.Console.WriteLine("Enter customer first name:");
                    value = System.Console.ReadLine();
                    listOfSearchedCustomer = _customerBL.SearchCustomer(criteria, value);
                    if (listOfSearchedCustomer == null)
                    {
                        System.Console.WriteLine("There is no matching result.");
                    }
                    else
                    {
                        foreach (Customers c in listOfSearchedCustomer)
                        {
                            System.Console.WriteLine(c.ToString());
                        }                        
                    }
                    return MenuType.SearchCustomerMenu;
                case "1":
                    return MenuType.CustomersMenu;
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