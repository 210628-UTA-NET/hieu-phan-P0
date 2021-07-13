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
        private string value;

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
            System.Console.WriteLine("[0] Main Menu");                        
        }

        public MenuType YourChoice()
        {
            System.Console.Write("Enter Your Choice: ");
            string userChoice = Console.ReadLine();

            switch (userChoice)
            {
                
                case "1":
                    System.Console.Write("Enter Your Input: ");
                    value = Console.ReadLine().ToUpper();
                    while(!Regex.IsMatch(value,@"^[A-Za-z]+$"))
                    {
                        System.Console.WriteLine("Attention: Invalid Input");
                        System.Console.Write("Re-enter Customer's First Name: ");
                        value = Console.ReadLine().ToUpper();
                    }
                    _newCustomer.Fname = value;
                    System.Console.WriteLine();
                    return MenuType.AddCustomerMenu;
                case "2":
                    System.Console.Write("Enter Your Input: ");
                    value = Console.ReadLine().ToUpper();
                    while(!Regex.IsMatch(value,@"^[A-Za-z]+$"))
                    {
                        System.Console.WriteLine("Attention: Invalid Input");
                        System.Console.Write("Re-enter Customer's Last Name: ");
                        value = Console.ReadLine().ToUpper();
                    }
                    _newCustomer.Lname = value;
                    return MenuType.AddCustomerMenu;
                case "3":
                    System.Console.Write("Enter Your Input: ");
                    value = Console.ReadLine().ToUpper();
                    while(!Regex.IsMatch(value,@"^[A-Za-z0-9 .,-]+$"))
                    {
                        System.Console.WriteLine("Attention: Invalid Input");
                        System.Console.Write("Re-enter Customer's Address: ");
                        value = Console.ReadLine().ToUpper();
                    }
                    _newCustomer.Address = value;
                    return MenuType.AddCustomerMenu;
                case "4":
                    System.Console.Write("Enter Your Input: ");
                    value = Console.ReadLine().ToUpper();
                    while(!Regex.IsMatch(value,@"^[A-Za-z .-]+$"))
                    {
                        System.Console.WriteLine("Attention: Invalid Input");
                        System.Console.Write("Re-enter Customer's City: ");
                        value = Console.ReadLine().ToUpper();
                    }
                    _newCustomer.City = value;
                    return MenuType.AddCustomerMenu;
                case "5":
                    System.Console.Write("Enter Your Input: ");
                    value = Console.ReadLine().ToUpper();
                    while(!Regex.IsMatch(value,@"^(?-i:A[LKSZRAEP]|C[AOT]|D[EC]|F[LM]|G[AU]|HI|I[ADLN]|K[SY]|LA|M[ADEHINOPST]|N[CDEHJMVY]|O[HKR]|P[ARW]|RI|S[CD]|T[NX]|UT|V[AIT]|W[AIVY])$"))
                    {
                        System.Console.WriteLine("Attention: Invalid Input");
                        System.Console.Write("Re-enter Customer's State: ");
                        value = Console.ReadLine().ToUpper();
                    }
                    _newCustomer.State = value;
                    return MenuType.AddCustomerMenu;
                case "6":
                    System.Console.Write("Enter Your Input: ");
                    value = Console.ReadLine();
                    while(!Regex.IsMatch(value,@"^[A-Za-z0-9.@]+$"))
                    {
                        System.Console.WriteLine("Attention: Invalid Input");
                        System.Console.Write("Re-enter Customer's Email: ");
                        value = Console.ReadLine();
                    }
                    _newCustomer.Email = value;
                    return MenuType.AddCustomerMenu;
                case "7":
                    System.Console.Write("Enter Your Input: ");
                    value = Console.ReadLine();
                    while(!Regex.IsMatch(value,@"\(?\d{3}\)?-? *\d{3}-? *-?\d{4}"))
                    {
                        System.Console.WriteLine("Attention: Invalid Input");
                        System.Console.Write("Re-enter Customer's Phone: ");
                        value = Console.ReadLine();
                    }
                    _newCustomer.Phone = value;
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
                    System.Console.WriteLine("Customer Was Created Succesfully!!!");
                    System.Console.Write("Enter To Continue");
                    System.Console.ReadLine();
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
                    return MenuType.AddCustomerMenu;
            } 
        }
    }
}