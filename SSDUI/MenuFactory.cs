using SSDBL;
using SSDDL;
namespace SSDUI
{
    public class MenuFactory : IFactory
    {
        public IMenu GetMenu(MenuType p_nemu)
        {
            switch (p_nemu)
            {
                case MenuType.MainMenu:
                    return new MainMenu();
                case MenuType.CustomersMenu:
                    return new CustomersMenu();
                case MenuType.AddCustomerMenu:
                    return new AddCustomerMenu(new CustomerBL(new CustomerRepository()));
                case MenuType.SearchCustomerMenu:
                    return new SearchCustomerMenu(new CustomerBL(new CustomerRepository()));
                case MenuType.StoreFrontsMenu:
                    return new StoreFrontsMenu();
                case MenuType.SearchStoreFrontMenu:
                    return new SearchStoreFrontMenu(new StoreFrontBL(new StoreFrontRepository()));
                default:
                    return null;
            }
        }
    }
}