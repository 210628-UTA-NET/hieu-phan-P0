using System;
using SSDModel;
using SSDDL;

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
        public Customers CreateCustomer()
        {
            System.Console.WriteLine("Enter Your Name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter Your Address: ");
            string address = Console.ReadLine();
            System.Console.WriteLine("Enter You Email: ");
            string email = Console.ReadLine();
            System.Console.WriteLine("Enter Your Phone Number: ");
            string phone = Console.ReadLine();
            return new Customers(name,address,email,phone);
        }
    }
}