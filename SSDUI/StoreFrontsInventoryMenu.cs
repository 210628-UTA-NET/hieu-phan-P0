using System;
using SSDModel;
using SSDBL;
using System.Collections.Generic;

namespace SSDUI
{
    public class StoreFrontsInventoryMenu : IMenu
    {
        private static List<StoreFronts> ListOfSearchedStoreFront;
        private static List<Inventories> theInventories = new List<Inventories>();
        private static List<Products> listOfProducts = new List<Products>();
        private List<int> productIDs = new List<int>();
        private static StoreFronts theStore;
        private IStoreFrontBL _sfBL;
        private IInventoryBL _invBL;
        private IProductBL _prodBL;
        public StoreFrontsInventoryMenu(IStoreFrontBL p_sfBL, IInventoryBL p_invBL, IProductBL p_prodBL)
        {
            _sfBL = p_sfBL;
            _invBL = p_invBL;
            _prodBL = p_prodBL;
        }
        public void Menu()
        {
            if(theStore != null)
            {
                listOfProducts = _prodBL.GetAllProducts();
                productIDs = new List<int>();
                foreach(Products p in listOfProducts)
                {
                    productIDs.Add(p.Id);
                }
                theInventories = new List<Inventories>();
                List<Inventories> listOfInventories = _invBL.GetAllInventories();
                foreach (Inventories inv in listOfInventories)
                {
                    if(inv.StoreFrontId == theStore.Id)
                    {
                        theInventories.Add(inv);
                    }
                }
                System.Console.Clear();
                System.Console.WriteLine("-----------------------------------------------------------------------");
                System.Console.WriteLine("Current Store :");
                System.Console.WriteLine(theStore.ToString());
                System.Console.WriteLine("-----------------------------------------------------------------------");
                System.Console.WriteLine("What Would You Like To Do?");
                System.Console.WriteLine("[1] View The Store Inventory/Products");
                System.Console.WriteLine("[2] View List Of All Products");
                System.Console.WriteLine("[3] Replenish The Store Inventory");
                System.Console.WriteLine("[0] Go Back");
                System.Console.WriteLine("-----------------------------------------------------------------------");
            }
            else
            {
                System.Console.Clear();
                System.Console.WriteLine("-----------------------------------------------------------------------");
                System.Console.WriteLine("Welcome To Store Front Inventory Menu!!!");
                System.Console.Write("Please Select A StoreFront Using Its [ID]: ");
                bool repeat = true;
                while(repeat)
                {
                    try
                    {
                        string userInput = Console.ReadLine();
                        ListOfSearchedStoreFront = _sfBL.SearchStoreFronts("id", userInput);
                        if (ListOfSearchedStoreFront.Count == 0)
                        {
                            System.Console.WriteLine("No Results.");
                            System.Console.WriteLine("Enter To Continue or 'quit' To Quit");
                            string string0 = Console.ReadLine().ToLower();
                            switch(string0)
                            {
                                case "quit":
                                repeat = false;
                                theStore = null;
                                break;
                                default:
                                System.Console.Write("Re-enter StoreFront ID: ");
                                break;
                            }
                        }
                        else
                        {
                            foreach(StoreFronts sf in ListOfSearchedStoreFront)
                            {
                                theStore = sf;
                            }
                            repeat = false;
                        }
                    }
                    catch (System.Exception)
                    {
                        System.Console.WriteLine("Input Was Not Valid");
                        System.Console.WriteLine("StoreFront Not Found");
                        System.Console.WriteLine("Enter To Continue or 'quit' To Quit");
                        string string0 = Console.ReadLine().ToLower();
                        switch(string0)
                        {
                            case "quit":
                            repeat = false;
                            theStore = null;
                            break;
                            default:
                            System.Console.Write("Re-enter StoreFront ID: ");
                            break;
                        }
                    }
                }

                if(theStore == null)
                {
                    System.Console.WriteLine("[0] Go Back");
                }
                else if(theStore != null)
                {
                    listOfProducts = _prodBL.GetAllProducts();
                    productIDs = new List<int>();
                    foreach(Products p in listOfProducts)
                    {
                        productIDs.Add(p.Id);
                    }
                    theInventories = new List<Inventories>();
                    List<Inventories> listOfInventories = _invBL.GetAllInventories();
                    foreach (Inventories inv in listOfInventories)
                    {
                        if(inv.StoreFrontId == theStore.Id)
                        {
                            theInventories.Add(inv);
                        }
                    }
                    System.Console.Clear();
                    System.Console.WriteLine("-----------------------------------------------------------------------");
                    System.Console.WriteLine("The Store Succesfully Located!!!");
                    System.Console.WriteLine(theStore.ToString());
                    System.Console.WriteLine("-----------------------------------------------------------------------");
                    System.Console.WriteLine("What Would You Like To Do?");
                    System.Console.WriteLine("[1] View The Store Inventory/Products");
                    System.Console.WriteLine("[2] View List Of All Products");
                    System.Console.WriteLine("[3] Replenish The Store Inventory");
                    System.Console.WriteLine("[0] Go Back");
                    System.Console.WriteLine("-----------------------------------------------------------------------");
                }
            }
        }

        public MenuType YourChoice()
        {
            System.Console.Write("Enter Your Choice: ");
            string userChoice = Console.ReadLine();

            switch (userChoice)
            {
                case "1":
                    System.Console.Clear();
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
                    System.Console.Write("Enter To Continue");
                    System.Console.ReadLine();
                    return MenuType.StoreFrontsInventoryMenu;
                case "2":
                    System.Console.Clear();
                    System.Console.WriteLine("-----------------------------------------------------------------------");
                    foreach (Products p in listOfProducts)
                    {
                        System.Console.WriteLine(p.ToString());
                    }
                    System.Console.WriteLine("-----------------------------------------------------------------------");
                    System.Console.Write("Enter To Continue");
                    System.Console.ReadLine();
                    return MenuType.StoreFrontsInventoryMenu;
                case "3":
                    ReplenishInventory(theStore);
                    return MenuType.StoreFrontsInventoryMenu;
                case "0":
                    theStore = null;
                    return MenuType.StoreFrontsMenu;
                default:
                    Console.WriteLine("Input was not correct");
                    Console.WriteLine("Press Enter to continue");
                    Console.ReadLine();
                    return MenuType.StoreFrontsInventoryMenu;
            } 
        }

        public void ReplenishInventory(StoreFronts p_sf)
        {
            bool productFlag = true;
            bool quantityFlag = true;
            System.Console.Write("Enter Product [ID]: ");
            while(productFlag)
            {
                try
                {
                    string check = "addNewProduct";
                    int productId = int.Parse(Console.ReadLine());
                    if(!productIDs.Contains(productId))
                    {
                        System.Console.WriteLine("Product ID Was Not Valid");
                        System.Console.WriteLine("Enter To Continue or 'quit' To Quit");
                        string string0 = Console.ReadLine().ToLower();
                        switch(string0)
                        {
                            case "quit":
                            productFlag = false;
                            quantityFlag = false;
                            break;
                            default:
                            System.Console.Write("Re-enter Product [ID]: ");
                            break;
                        }
                    }
                    else if(productIDs.Contains(productId))
                    {
                        foreach(Inventories inv in theInventories)
                        {
                            if(inv.ProductId == productId)
                            {
                                check = "replenish";
                            }
                        }
                        System.Console.Write("Enter Product Quantity: ");
                        quantityFlag = true;
                        while(quantityFlag)
                        {
                            try
                            {
                                int quantity = int.Parse(Console.ReadLine());
                                switch(check)
                                {
                                    case "addNewProduct":
                                    _invBL.AddNewProductInventory(theStore.Id,productId,quantity);
                                    System.Console.Clear();
                                    System.Console.WriteLine("-----------------------------------------------------------------------");
                                    System.Console.WriteLine("Product ID[" + productId + "] ||| Quantity: " + quantity +" (Added)");
                                    System.Console.WriteLine("-----------------------------------------------------------------------");
                                    break;
                                    case "replenish":
                                    _invBL.ReplenishInventory(theStore.Id,productId,quantity);
                                    System.Console.Clear();
                                    System.Console.WriteLine("-----------------------------------------------------------------------");
                                    System.Console.WriteLine("Product ID[" + productId + "] ||| Quantity: " + quantity +" (Replenished)");
                                    System.Console.WriteLine("-----------------------------------------------------------------------");
                                    break;
                                }
                            
                            }
                            catch(System.Exception)
                            {
                                System.Console.WriteLine("Input Was Not Valid - Quantity Must Be A Number");
                                System.Console.WriteLine("Enter To Continue or 'quit' To Quit");
                                string string1 = Console.ReadLine().ToLower();
                                switch(string1)
                                {
                                    case "quit":
                                    productFlag = false;
                                    quantityFlag = false;
                                    break;
                                    default:
                                    System.Console.Write("Re-enter Quantity: ");
                                    break;
                                } 
                            }
                            System.Console.WriteLine("What Would You Like To Do?");
                            System.Console.WriteLine("[1] Replenish Inventory");
                            System.Console.WriteLine("[0] Go Back");
                            string string0 = Console.ReadLine().ToLower();
                            switch(string0)
                            {
                                case "1":
                                System.Console.Write("Enter Product [ID]: ");
                                quantityFlag = false;
                                break;
                                case "0":
                                productFlag = false;
                                quantityFlag = false;
                                break;
                                default:
                                productFlag = false;
                                quantityFlag = false;
                                break;
                            } 
                        }
                    }
                }
                catch(System.Exception)
                {
                    System.Console.WriteLine("Input Was Not Valid - Product ID Must Be A Number");
                    System.Console.WriteLine("Product ID Not Found");
                    System.Console.WriteLine("Enter To Continue or 'quit' To Quit");
                    string string0 = Console.ReadLine().ToLower();
                    switch(string0)
                    {
                        case "quit":
                        productFlag = false;
                        quantityFlag = false;
                        break;
                        default:
                        System.Console.Write("Re-enter Product ID: ");
                        break;
                    } 
                }
            }
        }
    }
}