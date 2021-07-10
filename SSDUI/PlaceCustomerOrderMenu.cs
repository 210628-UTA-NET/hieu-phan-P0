using System;
using SSDModel;
using SSDBL;
using System.Collections.Generic;

namespace SSDUI
{
    public class PlaceCustomerOrderMenu : IMenu
    {
        private static List<Customers> listOfSearchedCustomer;
        private static List<StoreFronts> ListOfSearchedStoreFront;
        private static Customers theCustomer;
        private static StoreFronts theStore;
        private string criteria;
        private string value;
        private ICustomerBL _customerBL;
        private IStoreFrontBL _sfbl;
        

        public PlaceCustomerOrderMenu(ICustomerBL p_customerBL, IStoreFrontBL p_sfbl)
        {
            _customerBL = p_customerBL;
            _sfbl = p_sfbl;
        }
        public void Menu()
        {
            
            System.Console.WriteLine("-----------------------------------------------------------------------");
            System.Console.WriteLine("Welcome to Customer Order Placing Menu:");
            IdentifyCustomer();
            if (theCustomer != null)
            {
                System.Console.WriteLine("-----------------------------------------------------------------------");
                System.Console.WriteLine("The Current Customer:\n" + theCustomer.ToString());
                IdentifyStoreFront();
                if (theStore != null)
                {
                    
                    System.Console.WriteLine("-----------------------------------------------------------------------");
                    System.Console.WriteLine("The Current Store:\n" + theStore.ToString());
                    System.Console.WriteLine("-----------------------------------------------------------------------");
                    System.Console.WriteLine("The Store's Available Inventory:");
                    System.Console.WriteLine(theStore.DisplayInventory());
                    System.Console.WriteLine("-----------------------------------------------------------------------");

                    bool cont = true;
                    string userProductIndex;                  
                    string quantity;
                    string userChoice;
                    Orders newOrder = new Orders();
                    newOrder.Location = theStore;
                    while(cont)
                    {
                        try
                        {
                            System.Console.WriteLine("Select A Product Using The Product Index");
                            userProductIndex = Console.ReadLine();
                            System.Console.WriteLine(theStore.Inventory[int.Parse(userProductIndex)]);
                            System.Console.WriteLine("Enter the purchasing quantity: ");
                            try
                            {
                                quantity = Console.ReadLine();
                                bool quantityFlag = true;
                                while(quantityFlag)
                                {                                   
                                    if (int.Parse(quantity) < 0 )
                                    {
                                        System.Console.WriteLine("Purchasing quanity must be more than 0 and less than inventory quantity: ");
                                        System.Console.WriteLine("Re-enter the purchasing quantity: ");
                                        quantity = Console.ReadLine();
                                    }
                                    // else if (int.Parse(quantity) >= theStore.Inventory[int.Parse(userProductIndex)].Quantity)
                                    // {
                                    //     System.Console.WriteLine("Purchasing quanity must be more than 0 and less than inventory quantity: ");
                                    //     System.Console.WriteLine("Re-enter the purchasing quantity: ");
                                    //     quantity = Console.ReadLine();
                                    // }
                                    else
                                    {
                                        quantityFlag = false;
                                    }
                                }                                
                                LineItems lineItem = new LineItems(theStore.Inventory[int.Parse(userProductIndex)], int.Parse(quantity));
                                newOrder.OrderLineItems.Add(lineItem);
                                System.Console.WriteLine("-----------------------------------------------------------------------");
                                System.Console.WriteLine("Current Order:");
                                System.Console.WriteLine(newOrder.ToString());
                                System.Console.WriteLine("-----------------------------------------------------------------------");
                                System.Console.WriteLine("What would you like to do next?");
                                System.Console.WriteLine("[0] Proceed To Checkout");
                                System.Console.WriteLine("[1] Add A New Product");
                                System.Console.WriteLine("[8] To Exit");
                                System.Console.WriteLine("[9] Empty Your Shopping Cart");
                                userChoice = Console.ReadLine();
                                switch(userChoice)
                                {
                                    case "0":
                                        //add the order to both customer and storefront
                                        break;
                                    case "8":
                                        cont = false;
                                        break;
                                    case "9":
                                        newOrder.OrderLineItems.Clear();
                                        System.Console.WriteLine("-----------------------------------------------------------------------");
                                        System.Console.WriteLine("The Store's Available Inventory:");
                                        System.Console.WriteLine(theStore.DisplayInventory());
                                        System.Console.WriteLine("-----------------------------------------------------------------------");
                                        break;
                                    case "1":
                                        System.Console.WriteLine("-----------------------------------------------------------------------");
                                        System.Console.WriteLine("The Store's Available Inventory:");
                                        System.Console.WriteLine(theStore.DisplayInventory());
                                        System.Console.WriteLine("-----------------------------------------------------------------------");
                                        break;
                                    default:
                                        Console.WriteLine("Input was not correct");
                                        Console.WriteLine("Re-enter your choice:");
                                        userChoice = Console.ReadLine();
                                        break;
                                        
                                }

                            }
                            catch (System.Exception)
                            {
                                System.Console.WriteLine("Input was not valid");
                                System.Console.WriteLine("Re-enter the quantity: ");
                                quantity = Console.ReadLine();
                            }

                        }
                        catch(System.Exception)
                        {
                            System.Console.WriteLine("Input was not valid");
                            System.Console.WriteLine("Select A Product Using The Product Index Number");
                            userProductIndex = Console.ReadLine();
                        }
                    }
                    

                    // theCustomer.ListOfOrders.Add(anOrder)
                    // List<Products> availableProducts = theStore.Inventory;
                    // System.Console.WriteLine(availableProducts[0].ToString());
                }
            }

            System.Console.WriteLine("[1] To Add Customer");
            System.Console.WriteLine("[0] To Customers Menu");
        }

        public MenuType YourChoice()
        {
            string userChoice = Console.ReadLine();

            switch (userChoice)
            {
                case "0":
                    return MenuType.CustomersMenu;
                case "1":
                    return MenuType.AddCustomerMenu;
                default:
                    Console.WriteLine("Input was not correct");
                    Console.WriteLine("Press Enter to continue");
                    Console.ReadLine();
                    return MenuType.CustomersMenu;
            }
        }

        private void IdentifyStoreFront()
        {
            System.Console.WriteLine("-----------------------------------------------------------------------");
            System.Console.WriteLine("You need to chose a store front:");
            System.Console.WriteLine("-----------------------------------------------------------------------");
            System.Console.WriteLine("How would you like to chose a store front?");
            System.Console.WriteLine("[1] Using Address");
            System.Console.WriteLine("[0] Using Name");
            string userChoice = Console.ReadLine();
            switch(userChoice)
            {
                case "1":
                    criteria = "address";
                    break;
                case "0":
                    criteria = "name";
                    break;
                default:
                    System.Console.WriteLine("Input was not correct");
                    System.Console.WriteLine("Enter your choice again");
                    userChoice = Console.ReadLine();
                    break;
            }
            System.Console.WriteLine("Enter Search Value:");
            value = Console.ReadLine();
            ListOfSearchedStoreFront = _sfbl.SearchStoreFronts(criteria, value);
            if (ListOfSearchedStoreFront.Count == 0)
            {
                System.Console.WriteLine("-----------------------------------------------------------------------");
                System.Console.WriteLine("There is no matching result.");
            }
            else
            {
                for(int i = 0; i < ListOfSearchedStoreFront.Count; i++)
                {
                    System.Console.WriteLine("[" + i + "]"+ ListOfSearchedStoreFront[i].ToString());
                }
                System.Console.WriteLine("Select A Store Front Using The Store Index Number");
                string userChoiceIndex = Console.ReadLine();
                while(userChoiceIndex != "-99")
                {
                    try
                    {
                        theStore = ListOfSearchedStoreFront[int.Parse(userChoiceIndex)];
                        userChoiceIndex = "-99";
                    }
                    catch (System.Exception)
                    {
                        System.Console.WriteLine("Index Was Not Valid!!!");
                        System.Console.WriteLine("Select A Store Front Using The Store Index Number");
                        userChoiceIndex = Console.ReadLine();
                    }
                }                       
            }

        }

        

        private void IdentifyCustomer()
        {
            System.Console.WriteLine("-----------------------------------------------------------------------");
            System.Console.WriteLine("You need to identify yourself:");
            System.Console.WriteLine("-----------------------------------------------------------------------");
            System.Console.WriteLine("How would you like to identify yourself?");
            System.Console.WriteLine("[4] Using Phone Number");
            System.Console.WriteLine("[3] Using Email");
            System.Console.WriteLine("[2] Using Address");
            System.Console.WriteLine("[1] Using Last Name");
            System.Console.WriteLine("[0] Using First Name");
            string userChoice = Console.ReadLine();
            switch(userChoice)
            {
                case "4":
                    criteria = "phone";
                    break;
                case "3":
                    criteria = "email";
                    break;
                case "2":
                    criteria = "address";
                    break;
                case "1":
                    criteria = "lname";
                    break;
                case "0":
                    criteria = "fname";
                    break;
                default:
                    System.Console.WriteLine("Input was not correct");
                    System.Console.WriteLine("Enter your choice again");
                    userChoice = Console.ReadLine();
                    break;
            }
            System.Console.WriteLine("Enter Search Value:");
            value = Console.ReadLine();
            listOfSearchedCustomer = _customerBL.SearchCustomers(criteria, value);
            if (listOfSearchedCustomer.Count == 0)
            {
                System.Console.WriteLine("-----------------------------------------------------------------------");
                System.Console.WriteLine("There is no matching result.");
            }
            else
            {
                for(int i = 0; i < listOfSearchedCustomer.Count; i++)
                {
                    System.Console.WriteLine("[" + i + "]"+ listOfSearchedCustomer[i].ToString());
                }
                System.Console.WriteLine("Select A Customer Using The Customer Index Number");
                string userChoiceIndex = Console.ReadLine();
                while(userChoiceIndex != "-99")
                {
                    try
                    {
                        theCustomer = listOfSearchedCustomer[int.Parse(userChoiceIndex)];
                        userChoiceIndex = "-99";
                    }
                    catch (System.Exception)
                    {
                        System.Console.WriteLine("Index Was Not Valid!!!");
                        System.Console.WriteLine("Select A Customer Using The Customer Index Number");
                        userChoiceIndex = Console.ReadLine();
                    }
                }                       
            }
            
        }
    }
}