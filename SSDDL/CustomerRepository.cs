using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using SSDModel;

namespace SSDDL
{
    public class CustomerRepository : ICustomerRepository
    {
        private const string _filePath = "./../SSDDL/DataBase/Customers.json";
        private string _jsonString;

        public List<Customers> GetAllCustomers()
        {
            try
            {
                _jsonString = File.ReadAllText(_filePath);
            }
            catch (System.Exception)
            {
                throw new System.Exception("File path is invalid");
            }

            return JsonSerializer.Deserialize<List<Customers>>(_jsonString);
        }

        public Customers AddCustomer(Customers p_customer)
        {
            List<Customers> listOfCustomers = this.GetAllCustomers();
            listOfCustomers.Add(p_customer);
            _jsonString = JsonSerializer.Serialize(listOfCustomers, new JsonSerializerOptions{ WriteIndented = true});
            File.WriteAllText(_filePath,_jsonString);
            return p_customer;
        }

        public List<Customers> SearchCustomer(string p_criteria, string p_value)
        {
            List<Customers> listOfCustomers = this.GetAllCustomers();
            List<Customers> listOfSearchedCustomers = new List<Customers>();
            switch(p_criteria)
            {
                case "phone":
                    foreach(Customers c in listOfCustomers)
                    {
                        if (c.Phone == p_value)
                        {
                            listOfSearchedCustomers.Add(c);
                        }
                    }
                    return listOfSearchedCustomers;
                case "email":
                    foreach(Customers c in listOfCustomers)
                    {
                        if (c.Email == p_value)
                        {
                            listOfSearchedCustomers.Add(c);
                        }
                    }
                    return listOfSearchedCustomers;
                case "address":
                    foreach(Customers c in listOfCustomers)
                    {
                        if (c.Address == p_value)
                        {
                            listOfSearchedCustomers.Add(c);
                        }
                    }
                    return listOfSearchedCustomers;
                case "lname":
                    foreach(Customers c in listOfCustomers)
                    {
                        if (c.Lname == p_value)
                        {
                            listOfSearchedCustomers.Add(c);
                        }
                    }
                    return listOfSearchedCustomers;
                case "fname":
                    foreach(Customers c in listOfCustomers)
                    {
                        if (c.Fname == p_value)
                        {
                            listOfSearchedCustomers.Add(c);
                        }
                    }
                    return listOfSearchedCustomers;
                default:
                    return listOfSearchedCustomers;
            }
        }
    }
}