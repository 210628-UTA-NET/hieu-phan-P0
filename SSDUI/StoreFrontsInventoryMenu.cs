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
                System.Console.WriteLine("-----------------------------------------------------------------------");
                System.Console.WriteLine("Current Store :");
                System.Console.WriteLine(theStore.ToString());
                System.Console.WriteLine("-----------------------------------------------------------------------");
                System.Console.WriteLine("What Would You Like To Do?");
                System.Console.WriteLine("[1] View The Store Inventory");
                System.Console.WriteLine("[2] Replenish The Store Inventory");
                System.Console.WriteLine("[0] StoreFront Menu");
            }
            else
            {
                System.Console.WriteLine("-----------------------------------------------------------------------");
                System.Console.WriteLine("Welcome To Store Front Inventory Menu!!!");
                System.Console.WriteLine("Please Select A StoreFront Using Its ID:");
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
                                break;
                                default:
                                System.Console.WriteLine("Re-enter StoreFront ID: ");
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
                            break;
                            default:
                            System.Console.WriteLine("Re-enter StoreFront ID: ");
                            break;
                        }
                    }
                }
                System.Console.WriteLine("-----------------------------------------------------------------------");
                System.Console.WriteLine("The Store Succesfully Located!!!");
                System.Console.WriteLine(theStore.ToString());
                System.Console.WriteLine("-----------------------------------------------------------------------");
                System.Console.WriteLine("What Would You Like To Do?");
                System.Console.WriteLine("[1] View The Store Inventory");
                System.Console.WriteLine("[2] View List Of Products");
                System.Console.WriteLine("[3] Replenish The Store Inventory");
                System.Console.WriteLine("[0] StoreFront Menu");
            }
        }

        public MenuType YourChoice()
        {
            string userChoice = Console.ReadLine();

            switch (userChoice)
            {
                case "1":
                    theInventories = new List<Inventories>();
                    listOfProducts = _prodBL.GetAllProducts();
                    List<Inventories> listOfInventories = _invBL.GetAllInventories();
                    foreach (Inventories inv in listOfInventories)
                    {
                        if(inv.StoreFrontId == theStore.Id)
                        {
                            theInventories.Add(inv);
                        }
                    }
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
                    return MenuType.StoreFrontsInventoryMenu;
                case "2":
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

        }
    }
}