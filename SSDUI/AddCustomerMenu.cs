using System;
using SSDModel;
using SSDBL;
using SSDDL;

namespace SSDUI
{
    public class AddCustomerMenu : IMenu
    {
        private ICustomerBL _customer;

        public AddCustomerMenu(ICustomerBL p_customer)
        {
            _customer = p_customer;
        }
        public void Menu()
        {
            Customers customer = _customer.CreateCustomer();
            System.Console.WriteLine(_customer.SendCustomer(customer));
            
            System.Console.WriteLine("[0] Main Menu");
            System.Console.WriteLine("[1] Customer Menu");
            System.Console.WriteLine("[2] Add Customer");

        }

        public MenuType YourChoice()
        {
            string userChoice = Console.ReadLine();

            switch (userChoice)
            {
                case "0":
                    return MenuType.MainMenu;
                case "1":
                    return MenuType.CustomersMenu;
                case "2":
                    return MenuType.AddCustomerMenu;
                default:
                    Console.WriteLine("Input was not correct");
                    Console.WriteLine("Press Enter to continue");
                    Console.ReadLine();
                    return MenuType.CustomersMenu;
            } 
        }
    }
}