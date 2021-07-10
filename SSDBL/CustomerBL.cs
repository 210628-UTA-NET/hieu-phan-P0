using SSDModel;
using SSDDL;
using System.Collections.Generic;

namespace SSDBL
{
    public class CustomerBL : ICustomerBL
    {
        private ICustomerDL _repo;
        /// <summary>
        /// We are defining the dependenices this class needs in the constructor
        /// We do it this way (with interfaces) because we can easily switch out the implementation of RRDL when we want to change data source 
        /// (change from file system into database stored in the cloud)
        /// </summary>
        public CustomerBL(ICustomerDL p_repo)
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

        public List<Customers> SearchCustomers(string p_criteria, string p_value) {
            return _repo.SearchCustomers(p_criteria, p_value);
        }

        public Customers GetACustomer(int p_id)
        {
            return _repo.GetACustomer(p_id);
        }
    }
}