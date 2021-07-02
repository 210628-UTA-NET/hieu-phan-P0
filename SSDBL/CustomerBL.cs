using System;
using SSDModel;
using SSDDL;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace SSDBL
{
    public class CustomerBL : ICustomerBL
    {
        private IRepository _repo;
        /// <summary>
        /// We are defining the dependenices this class needs in the constructor
        /// We do it this way (with interfaces) because we can easily switch out the implementation of RRDL when we want to change data source 
        /// (change from file system into database stored in the cloud)
        /// </summary>
        public CustomerBL(IRepository p_repo)
        {
            _repo = p_repo;
        }

        public List<Customers> GetAllCustomers()
        {
            return _repo.GetAllCustomers();
        }

        public Customers AddCustomer(Customers p_customer)
        {
            _repo.AddCustomer(p_customer);
            return p_customer;
        }
        
    }
}