using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using SSDModel;

namespace SSDDL
{
    public class Repository : IRepository
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
    }
}