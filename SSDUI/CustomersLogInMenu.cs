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
        private IOrderBL _orderBL;
        private ILineItemBL _lineItemBL;
        

        public CustomersLogInMenu(ICustomerBL p_customerBL, IStoreFrontBL p_sfBL, IInventoryBL p_invBL, IProductBL p_prodBL, IOrderBL p_orderBL, ILineItemBL p_lineItemBL)
        {
            _customerBL = p_customerBL;
            _sfBL = p_sfBL;
            _invBL = p_invBL;
            _prodBL = p_prodBL;
            _orderBL = p_orderBL;
            _lineItemBL = p_lineItemBL;
        }

        
        public void Menu()
        {
            if (theCustomer != null)
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
            System.Console.WriteLine("Welcome To Customer Sign In Menu!!!");
            System.Console.WriteLine("Please Use Your ID and First Name To Sign In");
            int customerId;
            string fname = "";
            bool flag = true;
            System.Console.WriteLine("Enter Your ID: ");
            while(flag)
            {
                try
                {
                customerId = int.Parse(Console.ReadLine());                
                theCustomer = _customerBL.GetACustomer(customerId);
                if (theCustomer.Id != customerId)
                {
                    System.Console.WriteLine("Customer Not Found");
                    System.Console.WriteLine("Enter To Continue or 'quit' To Quit");
                    string string0 = Console.ReadLine().ToLower();
                    switch(string0)
                    {
                        case "quit":
                        flag = false;
                        theCustomer = null;
                        break;
                        default:
                        System.Console.WriteLine("Re-enter Your ID: ");
                        break;
                    }
                }
                else if (theCustomer.Id == customerId)
                {
                    System.Console.WriteLine("Enter Your Name: ");
                    fname = Console.ReadLine().ToUpper();
                    if(theCustomer.Fname == fname)
                    {
                        flag = false;
                        System.Console.WriteLine("Log In Successful !!!");
                        System.Console.WriteLine("-----------------------------------------------------------------------");
                        System.Console.WriteLine("Welcome " + theCustomer.Fname + ",");
                        System.Console.WriteLine("What would you like to do next?");
                        System.Console.WriteLine("[1] Place an Order");
                        System.Console.WriteLine("[0] Log Out");
                    }
                    else if (theCustomer.Fname != fname)
                    {                       
                        System.Console.WriteLine("Customer Not Found");
                        System.Console.WriteLine("Enter To Continue or 'quit' To Quit");
                        string string0 = Console.ReadLine().ToLower();
                        switch(string0)
                        {
                            case "quit":
                            flag = false;
                            theCustomer = null;
                            break;
                            default:
                            System.Console.WriteLine("Re-enter Your Name: ");
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

            if(theCustomer == null)
            {
                System.Console.WriteLine("-----------------------------------------------------------------------");
                System.Console.WriteLine("[0] Customer Menu");
            }
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
            int storeId;
            bool storeFlag = true;
            bool productFlag = true;
            bool quantityFlag = true;
            //Find a store
            System.Console.WriteLine("Enter A Store ID: ");
            while(storeFlag)
            {
                try
                {
                    storeId = int.Parse(Console.ReadLine());
                    theStore = _sfBL.GetAStore(storeId);
                    if (theStore.Id != storeId)
                    {
                        System.Console.WriteLine("Store Front Not Found");
                        System.Console.WriteLine("Enter To Continue or 'quit' To Quit");
                        string string0 = Console.ReadLine().ToLower();
                        switch(string0)
                        {
                            case "quit":
                            storeFlag = false;
                            productFlag = false;
                            quantityFlag = false;
                            break;
                            default:
                            System.Console.WriteLine("Re-enter The Store ID:");
                            break;
                        }

                    }
                    else if (theStore.Id == storeId)
                    {
                        //Display the store inventory
                        theInventories.Clear();
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
                        System.Console.WriteLine("Store " + theStore.Name + " Inventory");
                        for (int i = 0; i < theInventories.Count; i++)
                        {
                            System.Console.WriteLine("Product ID: " + theInventories[i].ProductId +
                                                        " ||| Product Name: " + listOfProducts[theInventories[i].ProductId - 1].Name +
                                                        " ||| Product Price: $" + listOfProducts[theInventories[i].ProductId - 1].Price +
                                                        " ||| Inventory Quantity: " + theInventories[i].Quantity);
                        }
                        System.Console.WriteLine("-----------------------------------------------------------------------");
                        //Start the order                       
                        
                        int productId;
                        double total = 0.0;
                        // int quantity = 0;
                        List<LineItems> lineItems = new List<LineItems>();
                        List<int> availableProductId = new List<int>();
                        foreach (Inventories inv in theInventories)
                        {
                            availableProductId.Add(inv.ProductId);
                        }
                        System.Console.WriteLine("What Product Would You Like To Order?");
                        System.Console.WriteLine("Use Product ID To Select Product :");
                        while(productFlag)
                        {
                            try
                            {
                                productId = int.Parse(Console.ReadLine());
                                if(!availableProductId.Contains(productId))
                                {
                                    System.Console.WriteLine("Product ID Not Found");
                                    System.Console.WriteLine("Enter To Continue or 'quit' To Quit");
                                    string string0 = Console.ReadLine().ToLower();
                                    switch(string0)
                                    {
                                        case "quit":
                                        storeFlag = false;
                                        productFlag = false;
                                        quantityFlag = false;
                                        break;
                                        default:
                                        System.Console.WriteLine("Re-enter Product ID:");
                                        break;
                                    }
                                }
                                else if(availableProductId.Contains(productId))
                                {
                                    //Display the selected product
                                    LineItems lineItem = new LineItems();
                                    Products theProduct = new Products();
                                    Inventories theProductInventory = new Inventories();
                                    foreach(Products p in listOfProducts)
                                    {
                                        if(p.Id == productId)
                                        {
                                            theProduct = p;
                                        }
                                    }

                                    foreach (Inventories inv in theInventories)
                                    {
                                        if (inv.ProductId == productId)
                                        {
                                            theProductInventory = inv;
                                        }
                                    }

                                    System.Console.WriteLine(theProduct.ToString()+ " Available Quantity: " + theProductInventory.Quantity);
                                    System.Console.WriteLine("Enter Your Quantity: ");
                                    quantityFlag = true;
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
                                                    storeFlag = false;
                                                    productFlag = false;
                                                    quantityFlag = false;
                                                    break;
                                                    default:
                                                    System.Console.WriteLine("Re-enter Product Quantity:");
                                                    break;
                                                }
                                            }
                                            else if(quantity > 0 && quantity <= theProductInventory.Quantity)
                                            {
                                                //Create a new LineItem and add to a list
                                                lineItem.ProductId = productId;
                                                lineItem.Quantity = quantity;
                                                lineItems.Add(lineItem);
                                                total += (theProduct.Price * quantity);
                                                System.Console.WriteLine("Product Name: " + theProduct.Name +
                                                                        " ||| Product Price: $" + theProduct.Price +
                                                                        " ||| Purchasing Quantity: " + quantity +
                                                                        " ||| Line Total: $" + (theProduct.Price*quantity));

                                                quantityFlag = false;
                                                System.Console.WriteLine("-----------------------------------------------------------------------");
                                                System.Console.WriteLine("You have " + lineItems.Count + " line item(s)");
                                                System.Console.WriteLine("Your Total Is: $" + total);
                                                System.Console.WriteLine("-----------------------------------------------------------------------");
                                                System.Console.WriteLine("What Would You Do Next?");
                                                System.Console.WriteLine("[1] Add More Product");
                                                System.Console.WriteLine("[2] Empty Cart");
                                                System.Console.WriteLine("[3] Check Out");
                                                System.Console.WriteLine("[0] Exit");
                                                string string1 = Console.ReadLine();
                                                switch(string1)
                                                {
                                                    case "1":
                                                        System.Console.WriteLine("-----------------------------------------------------------------------");
                                                        System.Console.WriteLine("Store " + theStore.Name + " Inventory");
                                                        for (int i = 0; i < theInventories.Count; i++)
                                                        {
                                                            System.Console.WriteLine("Product ID: [" + theInventories[i].ProductId +
                                                                                        "] ||| Product Name: " + listOfProducts[theInventories[i].ProductId - 1].Name +
                                                                                        " ||| Product Price: $" + listOfProducts[theInventories[i].ProductId - 1].Price +
                                                                                        " ||| Inventory Quantity: " + theInventories[i].Quantity);
                                                        }
                                                        System.Console.WriteLine("-----------------------------------------------------------------------");
                                                        System.Console.WriteLine("Use Product ID To Select Product :");
                                                        break;
                                                    case "2":
                                                        lineItems.Clear();
                                                        total = 0.0;
                                                        System.Console.WriteLine("-----------------------------------------------------------------------");
                                                        System.Console.WriteLine("You have " + lineItems.Count + " line item(s)");
                                                        System.Console.WriteLine("Your Total Is: $" + total);
                                                        System.Console.WriteLine("-----------------------------------------------------------------------");
                                                        System.Console.WriteLine("Store " + theStore.Name + " Inventory");
                                                        for (int i = 0; i < theInventories.Count; i++)
                                                        {
                                                            System.Console.WriteLine("Product ID: " + theInventories[i].ProductId +
                                                                                        " ||| Product Name: " + listOfProducts[theInventories[i].ProductId - 1].Name +
                                                                                        " ||| Product Price: $" + listOfProducts[theInventories[i].ProductId - 1].Price +
                                                                                        " ||| Inventory Quantity: " + theInventories[i].Quantity);
                                                        }
                                                        System.Console.WriteLine("-----------------------------------------------------------------------");
                                                        System.Console.WriteLine("Use Product ID To Select Product :");
                                                        break;
                                                    case "3":
                                                        storeFlag = false;
                                                        productFlag = false;
                                                        quantityFlag = false;
                                                        //Validate that the current store inv can satisfy the order??????????

                                                        //Create and write the new order to DB to get its auto generated orderID
                                                        Orders newOrder = new Orders();
                                                        newOrder.CustomerId = theCustomer.Id;
                                                        newOrder.StoreFrontId = theStore.Id;
                                                        newOrder.TotalPrice = total;
                                                        newOrder = _orderBL.AddAnOrder(newOrder);
                                                        //Add the orderID into all lineItems
                                                        //Write all lineItems in the list to the DB
                                                        foreach(LineItems li in lineItems)
                                                        {
                                                            li.OrderId = newOrder.Id;
                                                            _lineItemBL.AddALineItem(li);
                                                            //adjust the store inv quantity
                                                            foreach (Inventories inv in theInventories)
                                                            {
                                                                if(inv.ProductId == li.ProductId)
                                                                {
                                                                    int remainQuantity = inv.Quantity - li.Quantity;
                                                                    //write the remain quantity to db
                                                                    _invBL.UpdateInventoryQuantity(inv, remainQuantity);
                                                                }
                                                            }
                                                        }
                                                        //Print The Order Detail
                                                        System.Console.WriteLine("-----------------------------------------------------------------------");
                                                        System.Console.WriteLine("Order Submitted Successfully!!!");
                                                        System.Console.WriteLine("Order Detail:");
                                                        foreach(LineItems li in lineItems)
                                                        {
                                                            foreach(Products p in listOfProducts)
                                                            {
                                                                if(p.Id == li.ProductId)
                                                                {
                                                                    System.Console.WriteLine("Product Name: " + p.Name + 
                                                                                    " ||| Price: $" + p.Price + 
                                                                                    " ||| Purchased Quantity: " + li.Quantity +
                                                                                    " ||| Line Total: $" + (p.Price*li.Quantity));
                                                                }
                                                            }
                                                        }
                                                        System.Console.WriteLine("--------------------------------------------------------------------Order Total: $" + newOrder.TotalPrice);
                                                        lineItems.Clear();
                                                    break;
                                                    case "0":
                                                        lineItems.Clear();
                                                        storeFlag = false;
                                                        productFlag = false;
                                                        quantityFlag = false;
                                                        break;
                                                }
                                            }
                                        }
                                        catch (System.Exception e)
                                        {
                                            System.Console.WriteLine(e);
                                            System.Console.WriteLine("Input was not valid - Quantity Must Be A Number");
                                            System.Console.WriteLine("Enter To Continue or 'quit' To Quit");
                                            string string0 = Console.ReadLine().ToLower();
                                            switch(string0)
                                            {
                                                case "quit":
                                                storeFlag = false;
                                                productFlag = false;
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
                                System.Console.WriteLine("Input Was Not Valid - Product Id Must Be A Number");
                                System.Console.WriteLine("Enter To Continue or 'quit' To Quit");
                                string string0 = Console.ReadLine().ToLower();
                                switch(string0)
                                {
                                    case "quit":
                                    storeFlag = false;
                                    productFlag = false;
                                    quantityFlag = false;
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
                    System.Console.WriteLine("Input Was Not Valid - Store Id Must Be A Number");
                    System.Console.WriteLine("Enter To Continue or 'quit' To Quit");
                    string string0 = Console.ReadLine().ToLower();
                    switch(string0)
                    {
                        case "quit":
                        storeFlag = false;
                        productFlag = false;
                        quantityFlag = false;
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