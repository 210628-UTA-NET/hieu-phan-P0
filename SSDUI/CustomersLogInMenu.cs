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
        private static List<Inventories> theInventories = new List<Inventories>();
        private static List<Products> listOfProducts;
        private ICustomerBL _customerBL;
        private IStoreFrontBL _sfBL;
        private IInventoryBL _invBL;
        private IProductBL _prodBL;
        

        public CustomersLogInMenu(ICustomerBL p_customerBL, IStoreFrontBL p_sfBL, IInventoryBL p_invBL, IProductBL p_prodBL)
        {
            _customerBL = p_customerBL;
            _sfBL = p_sfBL;
            _invBL = p_invBL;
            _prodBL = p_prodBL;
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
            //Find a store
            System.Console.WriteLine("Enter A Store ID: ");
            while(flag)
            {
                try
                {
                    id = Console.ReadLine();
                    theStore = _sfBL.GetAStore(int.Parse(id));
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
                        List<Inventories> listOfInventories = _invBL.GetAllInventories();
                        foreach (Inventories inv in listOfInventories)
                        {
                            if(inv.StoreFrontId == theStore.Id)
                            {
                                theInventories.Add(inv);
                            }
                        }
                        listOfProducts = _prodBL.GetAllProducts();
                        System.Console.WriteLine("-----------------------------------------------------------------------");
                        System.Console.WriteLine("The Store's Inventory");
                        for (int i = 0; i < theInventories.Count; i++)
                        {
                            System.Console.WriteLine("Product ID: " + theInventories[i].ProductId +
                                                        " ||| Product Name: " + listOfProducts[theInventories[i].ProductId - 1].Name +
                                                        " ||| Product Price: $" + listOfProducts[theInventories[i].ProductId - 1].Price +
                                                        " ||| Inventory Quantity: " + theInventories[i].Quantity);
                        }
                        System.Console.WriteLine("-----------------------------------------------------------------------");
                        //Start the order
                        System.Console.WriteLine("What Product Would You Like To Order?");
                        System.Console.WriteLine("Use Product ID To Select Product :");
                        bool productFlag = true;
                        string productId = "";
                        double total = 0.0;
                        // int quantity = 0;
                        List<int> availableProductId = new List<int>();
                        foreach (Inventories inv in theInventories)
                        {
                            availableProductId.Add(inv.ProductId);
                        }
                        while(productFlag)
                        {
                            try
                            {
                                productId = Console.ReadLine();
                                if(!availableProductId.Contains(int.Parse(productId)))
                                {
                                    System.Console.WriteLine("Product ID Not Found");
                                    System.Console.WriteLine("Enter To Continue or 'quit' To Quit");
                                    string string0 = Console.ReadLine().ToLower();
                                    switch(string0)
                                    {
                                        case "quit":
                                        productFlag = false;
                                        break;
                                        default:
                                        System.Console.WriteLine("Re-enter Product ID:");
                                        break;
                                    }
                                }
                                else if(availableProductId.Contains(int.Parse(productId)))
                                {
                                    //Display the selected product
                                    Products theProduct = new Products();
                                    Inventories theProductInventory = new Inventories();
                                    foreach(Products p in listOfProducts)
                                    {
                                        if(p.Id == int.Parse(productId))
                                        {
                                            theProduct = p;
                                        }
                                    }

                                    foreach (Inventories inv in theInventories)
                                    {
                                        if (inv.ProductId == int.Parse(productId))
                                        {
                                            theProductInventory = inv;
                                        }
                                    }

                                    System.Console.WriteLine(theProduct.ToString()+ " ||| Available Quantity: " + theProductInventory.Quantity);
                                    System.Console.WriteLine("Enter Your Quantity: ");
                                    bool quantityFlag = true;
                                    while(quantityFlag)
                                    {
                                        try
                                        {
                                            int quantity = int.Parse(Console.ReadLine());
                                            if (quantity <= 0 || quantity > theProductInventory.Quantity)
                                            {
                                                System.Console.WriteLine("Quantity Must Be Greater Than 0 and Less Than The Available Quantity");
                                                System.Console.WriteLine("Enter To Continue or 'quit' To Quit");
                                                string string0 = Console.ReadLine().ToLower();
                                                switch(string0)
                                                {
                                                    case "quit":
                                                    productFlag = false;
                                                    break;
                                                    default:
                                                    System.Console.WriteLine("Re-enter Product ID:");
                                                    break;
                                                }
                                            }
                                            else if(quantity > 0 && quantity <= theProductInventory.Quantity)
                                            {
                                                
                                            }
                                        }
                                        catch (System.Exception)
                                        {
                                            System.Console.WriteLine("Input was not valid - Quantity Must Be A Number");
                                            System.Console.WriteLine("Enter To Continue or 'quit' To Quit");
                                            string string0 = Console.ReadLine().ToLower();
                                            switch(string0)
                                            {
                                                case "quit":
                                                quantityFlag = false;
                                                break;
                                                default:
                                                System.Console.WriteLine("Re-enter Product Quantity: ");
                                                break;
                                            }
                                        }
                                    }
                                }  
                            }
                            catch (System.Exception)
                            {
                                System.Console.WriteLine("Input was not valid - Id Must Be A Number");
                                System.Console.WriteLine("Enter To Continue or 'quit' To Quit");
                                string string0 = Console.ReadLine().ToLower();
                                switch(string0)
                                {
                                    case "quit":
                                    productFlag = false;
                                    break;
                                    default:
                                    System.Console.WriteLine("Re-enter Product ID: ");
                                    break;
                                }
                            }
                        }
                    }
                }
                catch (System.Exception )
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