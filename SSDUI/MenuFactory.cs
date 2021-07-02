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
                    return new AddCustomerMenu(new CustomerBL(new Repository()));
                default:
                    return null;
            }
        }
    }
}