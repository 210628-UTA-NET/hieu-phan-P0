using System;
using SSDModel;
using SSDBL;
using System.Collections.Generic;

namespace SSDUI
{
    public class StoreFrontsCustomerMenu : IMenu
    {
        private IStoreFrontBL _sfBL;
        public StoreFrontsCustomerMenu(IStoreFrontBL p_sfBL)
        {
            _sfBL = p_sfBL;
        }

        public void Menu()
        {
            throw new NotImplementedException();
        }

        public MenuType YourChoice()
        {
            throw new NotImplementedException();
        }
    }
}