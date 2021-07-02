using System;
using SSDModel;
using SSDDL;
using System.Text.RegularExpressions;

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

        public bool SendCustomer(Customers p_customer)
        {
            return _repo.WriteCustomerToFile(p_customer);
        }

        public Customers CreateCustomer()
        {
            string name;
            string address;
            string email;
            string phone;
            Customers customer = null;

            System.Console.WriteLine("Enter Customer's Name: ");            
            name = Console.ReadLine();
            while(!Regex.IsMatch(name,@"^[A-Za-z .]+$"))
            {
                System.Console.WriteLine("Attention: This field can only contain letters");
                System.Console.WriteLine("Re-enter Customer's Name: ");
                name = Console.ReadLine();
            }

            Console.WriteLine("Enter Customer's Address: ");
            address = Console.ReadLine();
            System.Console.WriteLine("Enter Customer's Email: ");
            email = Console.ReadLine();
            System.Console.WriteLine("Enter Customer's Phone Number: ");
            
            phone = Console.ReadLine();
            while(!Regex.IsMatch(phone,@"\(?\d{3}\)?-? *\d{3}-? *-?\d{4}"))
            {
                System.Console.WriteLine("Attention: This field can only contain 10 digits");
                System.Console.WriteLine("Re-enter Customer's Phone: ");
                phone = Console.ReadLine();
            }

            try
            {
                customer = new Customers(name,address,email,phone);                
            }
            catch (Exception e)
            {
                System.Console.WriteLine("somethingwrong");
                System.Console.WriteLine(e);
            }
            
            return customer;
        }
    }
}