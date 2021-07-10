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
            System.Console.Clear();
            System.Console.WriteLine("------------------------------------------");
            System.Console.WriteLine("Welcome To Customer Adding Menu:");
            System.Console.WriteLine("Enter Customer's First Name: ");
            System.Console.WriteLine("[1] First Name - " + _newCustomer.Fname);
            System.Console.WriteLine("[2] Last Name  - " + _newCustomer.Lname);
            System.Console.WriteLine("[3] Address    - " + _newCustomer.Address);
            System.Console.WriteLine("[4] City       - " + _newCustomer.City);
            System.Console.WriteLine("[5] State      - " + _newCustomer.State);
            System.Console.WriteLine("[6] Email      - " + _newCustomer.Email);
            System.Console.WriteLine("[7] Phone      - " + _newCustomer.Phone);
            System.Console.WriteLine("[8] Add Customer");
            System.Console.WriteLine("[9] Empty All Fields");
            System.Console.WriteLine("[0] MainMenu");                        
        }

        public MenuType YourChoice()
        {
            string userChoice = Console.ReadLine();

            switch (userChoice)
            {
                
                case "1":
                    _newCustomer.Fname = Console.ReadLine().ToUpper();
                    while(!Regex.IsMatch(_newCustomer.Fname,@"^[A-Za-z]+$"))
                    {
                        System.Console.WriteLine("Attention: Invalid Input");
                        System.Console.WriteLine("Re-enter Customer's First Name: ");
                        _newCustomer.Fname = Console.ReadLine().ToUpper();
                    }
                    System.Console.WriteLine();
                    return MenuType.AddCustomerMenu;
                case "2":
                    _newCustomer.Lname = Console.ReadLine().ToUpper();
                    while(!Regex.IsMatch(_newCustomer.Lname,@"^[A-Za-z]+$"))
                    {
                        System.Console.WriteLine("Attention: Invalid Input");
                        System.Console.WriteLine("Re-enter Customer's Last Name: ");
                        _newCustomer.Lname = Console.ReadLine().ToUpper();
                    }
                    return MenuType.AddCustomerMenu;
                case "3":
                    _newCustomer.Address = Console.ReadLine();
                    while(!Regex.IsMatch(_newCustomer.Address,@"^[A-Za-z0-9 .,-]+$"))
                    {
                        System.Console.WriteLine("Attention: Invalid Input");
                        System.Console.WriteLine("Re-enter Customer's Address: ");
                        _newCustomer.Address = Console.ReadLine();
                    }
                    return MenuType.AddCustomerMenu;
                case "4":
                    _newCustomer.City = Console.ReadLine();
                    while(!Regex.IsMatch(_newCustomer.City,@"^[A-Za-z .-]+$"))
                    {
                        System.Console.WriteLine("Attention: Invalid Input");
                        System.Console.WriteLine("Re-enter Customer's City: ");
                        _newCustomer.City = Console.ReadLine();
                    }
                    return MenuType.AddCustomerMenu;
                case "5":
                    _newCustomer.State = Console.ReadLine();
                    while(!Regex.IsMatch(_newCustomer.State,@"^[A-Za-z]+$"))
                    {
                        System.Console.WriteLine("Attention: Invalid Input");
                        System.Console.WriteLine("Re-enter Customer's State: ");
                        _newCustomer.State = Console.ReadLine();
                    }
                    return MenuType.AddCustomerMenu;
                case "6":
                    _newCustomer.Email = Console.ReadLine();
                    while(!Regex.IsMatch(_newCustomer.Email,@"^[A-Za-z0-9.@]+$"))
                    {
                        System.Console.WriteLine("Attention: Invalid Input");
                        System.Console.WriteLine("Re-enter Customer's Email: ");
                        _newCustomer.Email = Console.ReadLine();
                    }
                    return MenuType.AddCustomerMenu;
                case "7":
                    _newCustomer.Phone = Console.ReadLine();
                    while(!Regex.IsMatch(_newCustomer.Phone,@"\(?\d{3}\)?-? *\d{3}-? *-?\d{4}"))
                    {
                        System.Console.WriteLine("Attention: Invalid Input");
                        System.Console.WriteLine("Re-enter Customer's Phone: ");
                        _newCustomer.Phone = Console.ReadLine();
                    }
                    return MenuType.AddCustomerMenu;
                case "8":
                    try{
                    _customerBL.AddCustomer(_newCustomer);
                    }
                    catch (System.Exception e)
                    {
                        System.Console.WriteLine("Cannot Add Customer");
                        System.Console.WriteLine(e);
                    }
                    System.Console.WriteLine("Customer was entered succesfully!!!");
                    _newCustomer = new Customers();
                    return MenuType.MainMenu;
                case "9":
                    _newCustomer = new Customers();
                    return MenuType.AddCustomerMenu;
                case "0":
                    _newCustomer = new Customers();
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