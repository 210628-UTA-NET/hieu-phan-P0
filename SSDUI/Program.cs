﻿using System;
using SSDModel;
using SSDBL;
using SSDDL;
using System.Collections.Generic;
namespace SSDUI
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Customers> ListOfCustomers = new List<Customers>();

            IMenu storeMenu = new MainMenu();
            bool repeat = true;
            MenuType currentMenu = MenuType.MainMenu;
            IFactory menuFactory = new MenuFactory();

            while(repeat)
            {        
                // System.Console.Clear();       
                storeMenu.Menu();
                currentMenu = storeMenu.YourChoice();

                switch (currentMenu)
                {
                    case MenuType.MainMenu:
                        storeMenu = menuFactory.GetMenu(MenuType.MainMenu);
                        break;
                    case MenuType.CustomersMenu:
                        storeMenu = menuFactory.GetMenu(MenuType.CustomersMenu);
                        break;
                    case MenuType.CustomersLogInMenu:
                        storeMenu = menuFactory.GetMenu(MenuType.CustomersLogInMenu);
                        break;
                    case MenuType.CustomersViewStoreMenu:
                        storeMenu = menuFactory.GetMenu(MenuType.CustomersViewStoreMenu);
                        break;
                    case MenuType.CustomersSearchMenu:
                        storeMenu = menuFactory.GetMenu(MenuType.CustomersSearchMenu);
                        break;
                    case MenuType.AddCustomerMenu:
                        storeMenu = menuFactory.GetMenu(MenuType.AddCustomerMenu);
                        break;
                    case MenuType.StoreFrontsMenu:
                        storeMenu = menuFactory.GetMenu(MenuType.StoreFrontsMenu);
                        break;
                    case MenuType.StoreFrontsCustomerMenu:
                        storeMenu = menuFactory.GetMenu(MenuType.StoreFrontsCustomerMenu);
                        break;
                    case MenuType.StoreFrontsInventoryMenu:
                        storeMenu = menuFactory.GetMenu(MenuType.StoreFrontsInventoryMenu);
                        break;
                    case MenuType.StoreFrontsOrderSearchMenu:
                        storeMenu = menuFactory.GetMenu(MenuType.StoreFrontsOrderSearchMenu);
                        break;
                    case MenuType.StoreFrontsSearchMenu:
                        storeMenu = menuFactory.GetMenu(MenuType.StoreFrontsSearchMenu);
                        break;
                    case MenuType.Exit:
                        repeat = false;
                        break;                    
                    default:
                        Console.WriteLine("Cannot proceed ||| Try again");
                        break;
                }
            }
        }
    }
}
