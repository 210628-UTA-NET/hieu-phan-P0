using System;
using System.Collections.Generic;
using SSDModel;
using SSDBL;
namespace SSDUI
{
    public class CustomersLogInMenu : IMenu
    {
        private static Customers theCustomer;
        private static StoreFronts theStore;
        private ICustomerBL _customerBL;
        private IStoreFrontBL _sfbl;
        

        public CustomersLogInMenu(ICustomerBL p_customerBL, IStoreFrontBL p_sfbl)
        {
            _customerBL = p_customerBL;
            _sfbl = p_sfbl;
        }

        public void Menu()
        {
            System.Console.WriteLine("-----------------------------------------------------------------------");
            System.Console.WriteLine("Welcome To Customer Sign In Menu!!!");
            System.Console.WriteLine("Please Use Your ID and First Name To Sign In");
            string id = "";
            string fname = "";
            bool flag = true;
            System.Console.WriteLine("Enter Your ID: ");
            while(flag)
            {
                try
                {
                id = Console.ReadLine();                
                theCustomer = _customerBL.GetACustomer(int.Parse(id));
                if (theCustomer == null)
                {
                    System.Console.WriteLine("Customer Not Found");
                    System.Console.WriteLine("Enter To Continue or 'quit' To Quit");
                    string string0 = Console.ReadLine().ToLower();
                    switch(string0)
                    {
                        case "quit":
                        flag = false;
                        break;
                        default:
                        System.Console.WriteLine("Re-enter Your ID: ");
                        break;
                    }
                }
                else if (theCustomer != null)
                {
                    System.Console.WriteLine("Enter Your Name: ");
                    fname = Console.ReadLine().ToUpper();
                    if(theCustomer.Fname == fname)
                    {
                        flag = false;
                        System.Console.WriteLine("Log In Successful !!!");
                    }
                    else if (theCustomer.Fname != fname)
                    {
                        theCustomer = null;
                        System.Console.WriteLine("Customer Not Found");
                        System.Console.WriteLine("Enter To Continue or 'quit' To Quit");
                        string string0 = Console.ReadLine().ToLower();
                        switch(string0)
                        {
                            case "quit":
                            flag = false;
                            break;
                            default:
                            System.Console.WriteLine("Re-enter Your ID: ");
                            break;
                        }
                    }                    
                }
                }
                catch(System.Exception)
                {
                    System.Console.WriteLine("Input was not valid - Id Must Be A Number");
                    System.Console.WriteLine("Customer Not Found");
                    System.Console.WriteLine("Enter To Continue or 'quit' To Quit");
                    string string0 = Console.ReadLine().ToLower();
                    switch(string0)
                    {
                        case "quit":
                        flag = false;
                        break;
                        default:
                        System.Console.WriteLine("Re-enter Your ID: ");
                        break;
                    }
                    
                }
            }
            if(theCustomer != null)
            {
                System.Console.WriteLine("-----------------------------------------------------------------------");
                System.Console.WriteLine("Welcome " + theCustomer.Fname + ",");
                System.Console.WriteLine("What would you like to do next?");
                System.Console.WriteLine("[1] Place an Order");
                System.Console.WriteLine("[0] Log Out");
            }
            else
            {
                System.Console.WriteLine("-----------------------------------------------------------------------");
                System.Console.WriteLine("[0] Customer Menu");
            }
        }

        public MenuType YourChoice()
        {
            string userChoice = Console.ReadLine();

            switch (userChoice)
            {
                case "1":
                    PlaceOrder(theCustomer);
                    return MenuType.CustomersLogInMenu;
                case "0":
                    theCustomer = null;
                    return MenuType.CustomersMenu;
                default:
                    Console.WriteLine("Input was not correct");
                    Console.WriteLine("Press Enter to continue");
                    Console.ReadLine();
                    return MenuType.CustomersMenu;
            }
        }

        public void PlaceOrder(Customers p_customer)
        {
            string id = "";
            bool flag = true;
            System.Console.WriteLine("Enter A Store ID: ");
            while(flag)
            {
                try
                {
                    id = Console.ReadLine();
                    theStore = _sfbl.GetAStore(int.Parse(id));
                    if (theStore == null)
                    {
                        System.Console.WriteLine("Store Front Not Found");
                        System.Console.WriteLine("Enter To Continue or 'quit' To Quit");
                        string string0 = Console.ReadLine().ToLower();
                        switch(string0)
                        {
                            case "quit":
                            flag = false;
                            break;
                            default:
                            System.Console.WriteLine("Re-enter The Store ID:");
                            break;
                        }

                    }
                    else if (theStore != null)
                    {
                        //Display the store inventory
                    }
                }
                catch (System.Exception)
                {
                    System.Console.WriteLine("Input was not valid - Id Must Be A Number");
                    System.Console.WriteLine("Store Front Not Found");
                    System.Console.WriteLine("Enter To Continue or 'quit' To Quit");
                    string string0 = Console.ReadLine().ToLower();
                    switch(string0)
                    {
                        case "quit":
                        flag = false;
                        break;
                        default:
                        System.Console.WriteLine("Re-enter The Store ID: ");
                        break;
                    }
                }
            }
            
        }

    }
}