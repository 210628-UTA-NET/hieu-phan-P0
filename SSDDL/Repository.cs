using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using SSDModel;

namespace SSDDL
{
    public class Repository : IRepository
    {
        private const string _filePath = "./DataBase/Customers.json";
        private string _jsonString;
        public bool AddCustomer(Customers p_customer)
        {
            // Read all the customers from json file then add new customer then write to json file -- to keep json file from being overriden
            try
            {
                _jsonString = File.ReadAllText(_filePath);
            }
            catch (System.Exception)
            {
                throw new System.Exception("File path is invalid");
            }
            
            List<Customers> listOfCustomers = JsonSerializer.Deserialize<List<Customers>>(_jsonString);
            listOfCustomers.Add(p_customer);
            _jsonString = JsonSerializer.Serialize(listOfCustomers, new JsonSerializerOptions{ WriteIndented = true});
            File.WriteAllText(_filePath,_jsonString);
            return true;
        }
    }
}