using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using System.IO;
using SSDBL;
using SSDDL;
using SSDDL.Entities;

namespace SSDUI
{
    public class MenuFactory : IFactory
    {
        public IMenu GetMenu(MenuType p_nemu)
        {
            //Get the configuration from the appsetting.json file
            var configuration = new ConfigurationBuilder()
                                .SetBasePath(Directory.GetCurrentDirectory())
                                .AddJsonFile("appsetting.json")
                                .Build();
            //Get the connection string from the configuration
            string connectionString = configuration.GetConnectionString("Reference2DB");
            //Build the options and use it for connection to the DB
            DbContextOptions<DemoDbContext> options = new DbContextOptionsBuilder<DemoDbContext>()
                                                            .UseSqlServer(connectionString)
                                                            .Options;
            

            switch (p_nemu)
            {
                case MenuType.MainMenu:
                    return new MainMenu();
                case MenuType.CustomersMenu:
                    return new CustomersMenu();
                case MenuType.CustomersLogInMenu:
                    return new CustomersLogInMenu(new CustomerBL(new CustomerDL(new DemoDbContext(options))), 
                                                    new StoreFrontBL(new StoreFrontDL(new DemoDbContext(options))),
                                                    new InventoryBL(new InventoryDL(new DemoDbContext(options))),
                                                    new ProductBL(new ProductDL(new DemoDbContext(options))));
                case MenuType.CustomersViewStoreMenu:
                    return new CustomersViewStoreMenu(new StoreFrontBL(new StoreFrontDL(new DemoDbContext(options))));
                case MenuType.AddCustomerMenu:
                    return new AddCustomerMenu(new CustomerBL(new CustomerDL(new DemoDbContext(options))));
                case MenuType.SearchCustomerMenu:
                    return new SearchCustomerMenu(new CustomerBL(new CustomerDL(new DemoDbContext(options))));
                case MenuType.StoreFrontsMenu:
                    return new StoreFrontsMenu();
                case MenuType.SearchStoreFrontMenu:
                    return new SearchStoreFrontMenu(new StoreFrontBL(new StoreFrontDL(new DemoDbContext(options))));
                default:
                    return null;
            }
        }
    }
}