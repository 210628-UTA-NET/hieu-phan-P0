using System;
using SSDModel;
using System.Collections.Generic;
namespace SSDUI
{
    class Program
    {
        static void Main(string[] args)
        {
            // Customers c1 = new Customers("Hieu","1234 Royal St.","hieu@gmail.com", "123-456-7890");
            // Console.WriteLine(c1.ToString());
            // // Create line items
            // LineItems i1 = new LineItems("item1", 1, 10.00);
            // LineItems i2 = new LineItems("item2", 2, 20.00);
            // LineItems i3 = new LineItems("item3", 3, 30.00);
            // // Add line items into List<LineItems> l1
            // List<LineItems> l1 = new List<LineItems>();
            // l1.Add(i1);
            // l1.Add(i2);
            // l1.Add(i3);
            // // Create an order with l1 list
            // Orders o1 = new Orders(l1, "Texas");
            // // Add o1 to customer c1 listOfOrders
            // c1.AddToListOfOrders(o1);
            // Console.WriteLine(c1.ToString());
            // Console.WriteLine(c1.ListOfOrders[0].ToString());
            List<Customers> ListOfCustomers = new List<Customers>();

            IMenu mainMenu = new MainMenu();
            bool repeat = true;
            MenuType currentMenu = MenuType.MainMenu;

            while(repeat)
            {
                
                mainMenu.Menu();
                currentMenu = mainMenu.YourChoice();

                switch (currentMenu)
                {
                    case MenuType.MainMenu:
                        mainMenu = new MainMenu();
                        break;
                    case MenuType.CustomersMenu:
                        mainMenu = new CustomersMenu();
                        break;
                    case MenuType.CustomersInfo:
                        System.Console.WriteLine("Enter Your Name: ");
                        string name = Console.ReadLine();
                        Console.WriteLine("Enter Your Address: ");
                        string address = Console.ReadLine();
                        System.Console.WriteLine("Enter You Email: ");
                        string email = Console.ReadLine();
                        System.Console.WriteLine("Enter Your Phone Number: ");
                        string phone = Console.ReadLine();
                        Customers customer = new Customers(name,address,email,phone);
                        ListOfCustomers.Add(customer);
                        System.Console.WriteLine("----------------------------------------");
                        System.Console.WriteLine("Customer has been succesfully registered");
                        System.Console.WriteLine("----------------------------------------");
                        mainMenu = new CustomersMenu();
                        break;
                    case MenuType.PrintListOfCustomer:
                        System.Console.WriteLine("Number of customers in the list: " + ListOfCustomers.Count);
                        for (int i = 0; i < ListOfCustomers.Count; i++)
                        {
                            System.Console.WriteLine(ListOfCustomers[i].ToString());
                        };
                        break;
                    case MenuType.Exit:
                        repeat = false;
                        break;                    
                    default:
                        Console.WriteLine("Cannot proceed /// Try again");
                        break;
                }
            }
        }
    }
}
