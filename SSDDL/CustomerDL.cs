using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using SSDModel;

namespace SSDDL
{
    public class CustomerDL : ICustomerDL
    {
        
        private Entities.DemoDbContext _context;
        public CustomerDL (Entities.DemoDbContext p_context)
        {
            _context = p_context;
        }

        public List<Customers> GetAllCustomers()
        {
            return _context.Customers.Select(
                cust =>
                    new Customers()
                    {
                        Id = cust.Id,
                        Fname = cust.Fname,
                        Lname = cust.Lname,
                        Address = cust.Address,
                        City = cust.City,
                        State = cust.State,
                        Email = cust.Email,
                        Phone = cust.Phone
                    }
            ).ToList();
        }

        public Customers AddCustomer(Customers p_customer)
        {
            _context.Customers.Add(new Entities.Customer{
                Fname = p_customer.Fname,
                Lname = p_customer.Lname,
                Address = p_customer.Address,
                City = p_customer.City,
                State = p_customer.State,
                Email = p_customer.Email,
                Phone = p_customer.Phone
            });

            _context.SaveChanges();

            var theCustomer = (from cus in _context.Customers
                            orderby cus.Id
                            where cus.Fname == p_customer.Fname &&
                                    cus.Lname == p_customer.Lname &&
                                    cus.Phone == p_customer.Phone 
                            select cus).Last();
            p_customer.Id = theCustomer.Id;
            
            return p_customer;
        }

        public Customers GetACustomer(int p_id)
        {
            List<Customers> listOfCustomers = this.GetAllCustomers();
            Customers theCustomer = new Customers();
            foreach(Customers c in listOfCustomers)
            {
                if (c.Id == p_id)
                    {
                        theCustomer = c;
                    }
            }
            
            return theCustomer;
        }
       

        public List<Customers> SearchCustomers(string p_criteria, string p_value)
        {
            List<Customers> listOfCustomers = this.GetAllCustomers();
            List<Customers> listOfSearchedCustomers = new List<Customers>();
            switch(p_criteria)
            {
                case "phone":
                    try
                    {
                        foreach(Customers c in listOfCustomers)
                        {
                            if (c.Phone == p_value)
                            {
                                listOfSearchedCustomers.Add(c);
                            }
                        }
                        return listOfSearchedCustomers;
                    }
                    catch(System.Exception e)
                    {
                        System.Console.WriteLine("Something Wrong");
                        System.Console.WriteLine(e);
                        return listOfSearchedCustomers;
                    }
                case "email":
                    try
                    {
                        foreach(Customers c in listOfCustomers)
                        {
                            if (c.Email == p_value)
                            {
                                listOfSearchedCustomers.Add(c);
                            }
                        }
                        return listOfSearchedCustomers;
                    }
                    catch(System.Exception e)
                    {
                        System.Console.WriteLine("Something Wrong");
                        System.Console.WriteLine(e);
                        return listOfSearchedCustomers;
                    }
                case "address":
                    try
                    {
                        foreach(Customers c in listOfCustomers)
                        {
                            if (c.Address == p_value)
                            {
                                listOfSearchedCustomers.Add(c);
                            }
                        }
                        return listOfSearchedCustomers;
                    }
                    catch(System.Exception e)
                    {
                        System.Console.WriteLine("Something Wrong");
                        System.Console.WriteLine(e);
                        return listOfSearchedCustomers;
                    }
                case "lname":
                    try
                    {
                        foreach(Customers c in listOfCustomers)
                        {
                            if (c.Lname == p_value)
                            {
                                listOfSearchedCustomers.Add(c);
                            }
                        }
                        return listOfSearchedCustomers;
                    }
                    catch(System.Exception e)
                    {
                        System.Console.WriteLine("Something Wrong");
                        System.Console.WriteLine(e);
                        return listOfSearchedCustomers;
                    }
                case "fname":
                    try
                    {
                        foreach(Customers c in listOfCustomers)
                        {
                            if (c.Fname == p_value)
                            {
                                listOfSearchedCustomers.Add(c);
                            }
                        }
                        return listOfSearchedCustomers;
                    }
                    catch(System.Exception e)
                    {
                        System.Console.WriteLine("Something Wrong");
                        System.Console.WriteLine(e);
                        return listOfSearchedCustomers;
                    }
                default:
                    // listOfSearchedCustomers = null;
                    return listOfSearchedCustomers;
            }
        }

        

        //-------------------------------------------JSON--------------------------------------------
        // private const string _filePath = "./../SSDDL/DataBase/Customers.json";
        // private string _jsonString;

        // public List<Customers> GetAllCustomers()
        // {
        //     try
        //     {
        //         _jsonString = File.ReadAllText(_filePath);
        //     }
        //     catch (System.Exception)
        //     {
        //         throw new System.Exception("File path is invalid");
        //     }

        //     return JsonSerializer.Deserialize<List<Customers>>(_jsonString);           
        // }

        // public Customers AddCustomer(Customers p_customer)
        // {
        //     List<Customers> listOfCustomers = this.GetAllCustomers();
        //     listOfCustomers.Add(p_customer);
        //     _jsonString = JsonSerializer.Serialize(listOfCustomers, new JsonSerializerOptions{ WriteIndented = true});
        //     File.WriteAllText(_filePath,_jsonString);
        //     return p_customer;
        // }
    }
}