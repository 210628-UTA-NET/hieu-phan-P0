using System;
using SSDModel;
using SSDBL;
using SSDDL;
using System.Text.RegularExpressions;

namespace SSDUI
{
    public class AddCustomerMenu : IMenu
    {
        private static Customers _customer = new Customers();
        private ICustomerBL _customerBL;

        public AddCustomerMenu(ICustomerBL p_customer)
        {
            _customerBL = p_customer;
        }
        public void Menu()
        {
            System.Console.WriteLine("------------------------------------------");
            System.Console.WriteLine("Enter Customer's Name: ");            
            string name = Console.ReadLine();
            while(!Regex.IsMatch(name,@"^[A-Za-z .]+$"))
            {
                System.Console.WriteLine("Attention: This field can only contain letters");
                System.Console.WriteLine("Re-enter Customer's Name: ");
                name = Console.ReadLine();
            }

            Console.WriteLine("Enter Customer's Address: ");
            string address = Console.ReadLine();
            System.Console.WriteLine("Enter Customer's Email: ");
            string email = Console.ReadLine();
            System.Console.WriteLine("Enter Customer's Phone Number: ");
            
            string phone = Console.ReadLine();
            while(!Regex.IsMatch(phone,@"\(?\d{3}\)?-? *\d{3}-? *-?\d{4}"))
            {
                System.Console.WriteLine("Attention: This field can only contain 10 digits");
                System.Console.WriteLine("Re-enter Customer's Phone: ");
                phone = Console.ReadLine();
            }


            _customer.Name = name;
            _customer.Address = address;
            _customer.Email = email;
            _customer.Phone = phone;

            System.Console.WriteLine("--------------------------------------------------");
            System.Console.WriteLine("The information of the customer you just enter is:");
            System.Console.WriteLine(_customer.ToString());
            System.Console.WriteLine("--------------------------------------------------");

            // if (_customerBL.AddCustomer(_customer))
            // {
            //     System.Console.WriteLine("------------------------------------------");
            //     System.Console.WriteLine("The Customer Has Been Added Succesfully!!!");
            //     System.Console.WriteLine("------------------------------------------");
            // }
            
            System.Console.WriteLine("[3] Add Customer");
            System.Console.WriteLine("[2] Re-enter Customer Info");
            System.Console.WriteLine("[1] Customer Menu");
            System.Console.WriteLine("[0] Main Menu");

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
                case "3":
                    _customerBL.AddCustomer(_customer);
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