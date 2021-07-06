using System;
using SSDModel;
using SSDBL;
using System.Text.RegularExpressions;

namespace SSDUI
{
    public class AddCustomerMenu : IMenu
    {
        private static Customers _newCustomer = new Customers();
        private ICustomerBL _customerBL;

        public AddCustomerMenu(ICustomerBL p_customerBL)
        {
            _customerBL = p_customerBL;
        }
        public void Menu()
        {
            System.Console.WriteLine("------------------------------------------");
            System.Console.WriteLine("Enter Customer's First Name: ");            
            string fname = Console.ReadLine();
            while(!Regex.IsMatch(fname,@"^[A-Za-z .]+$"))
            {
                System.Console.WriteLine("Attention: This field can only contain letters");
                System.Console.WriteLine("Re-enter Customer's First Name: ");
                fname = Console.ReadLine();
            }

            System.Console.WriteLine("Enter Customer's Last Name: ");            
            string lname = Console.ReadLine();
            while(!Regex.IsMatch(lname,@"^[A-Za-z .]+$"))
            {
                System.Console.WriteLine("Attention: This field can only contain letters");
                System.Console.WriteLine("Re-enter Customer's Last Name: ");
                lname = Console.ReadLine();
            }

            Console.WriteLine("Enter Customer's Address: ");
            string address = Console.ReadLine();
            while(!Regex.IsMatch(address,@"^[A-Za-z0-9 .,-]+$"))
            {
                System.Console.WriteLine("Attention: This address is not valid");
                System.Console.WriteLine("Re-enter Customer's Address: ");
                address = Console.ReadLine();
            }

            System.Console.WriteLine("Enter Customer's Email: ");
            string email = Console.ReadLine();
            while(!Regex.IsMatch(email,@"^[A-Za-z0-9.@]+$"))
            {
                System.Console.WriteLine("Attention: This email is not valid");
                System.Console.WriteLine("Re-enter Customer's Email: ");
                email = Console.ReadLine();
            }

            System.Console.WriteLine("Enter Customer's Phone Number: ");            
            string phone = Console.ReadLine();
            while(!Regex.IsMatch(phone,@"\(?\d{3}\)?-? *\d{3}-? *-?\d{4}"))
            {
                System.Console.WriteLine("Attention: This field can only contain 10 digits");
                System.Console.WriteLine("Re-enter Customer's Phone: ");
                phone = Console.ReadLine();
            }

            _newCustomer.Fname = fname;
            _newCustomer.Lname = lname;
            _newCustomer.Address = address;
            _newCustomer.Email = email;
            _newCustomer.Phone = phone;

            System.Console.WriteLine("--------------------------------------------------");
            System.Console.WriteLine("The information of the customer you just enter is:");
            System.Console.WriteLine(_newCustomer.ToString());
            System.Console.WriteLine("--------------------------------------------------");
            
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
                    try{
                    _customerBL.AddCustomer(_newCustomer);
                    }
                    catch (System.Exception e)
                    {
                        System.Console.WriteLine("Cannot Add Customer");
                        System.Console.WriteLine(e);
                    }
                    System.Console.WriteLine("Customer was entered succesfully!!!");
                    return MenuType.CustomersMenu;
                default:
                    Console.WriteLine("Input was not correct");
                    Console.WriteLine("Press Enter to continue");
                    Console.ReadLine();
                    return MenuType.CustomersMenu;
            } 
        }
    }
}