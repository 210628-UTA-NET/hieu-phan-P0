using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using SSDModel;
using System.Linq;

namespace SSDDL
{
    public class StoreFrontDL : IStoreFrontDL
    {
        private Entities.DemoDbContext _context;
        public StoreFrontDL(Entities.DemoDbContext p_context)
        {
            _context = p_context;
        }

        public List<StoreFronts> GetAllStoreFronts()
        {
            return _context.StoreFronts.Select(
                sf =>
                    new StoreFronts()
                    {
                        Id = sf.Id,
                        Name = sf.Name,
                        Address = sf.Address,
                        City = sf.City,
                        State = sf.State
                    }
            ).ToList();
        }

        public StoreFronts GetAStore(int p_id)
        {
            List<StoreFronts> listOfStoreFronts = this.GetAllStoreFronts();
            StoreFronts theStore = new StoreFronts();
            foreach (StoreFronts sf in listOfStoreFronts)
            {
                if (sf.Id == p_id)
                {
                    theStore = sf;
                }
            }
            return theStore;
        }

        public List<StoreFronts> SearchStoreFront(string p_criteria, string p_value)
        {
            List<StoreFronts> listOfStoreFronts = this.GetAllStoreFronts();
            List<StoreFronts> listOfSearchedStoreFronts = new List<StoreFronts>();
            switch(p_criteria)
            {
                case "id":
                    foreach(StoreFronts s in listOfStoreFronts)
                    {
                        if (s.Id == int.Parse(p_value))
                        {
                            listOfSearchedStoreFronts.Add(s);
                        }
                    }
                    return listOfSearchedStoreFronts;
                case "name":
                    //loop through the listOfStoreFront, 
                    //if the storefront in the list match the p_value
                    //add that storefront to the listOfSearchedStoreFronts
                    for(int i = 0; i < listOfStoreFronts.Count; i++)
                    {
                        if (listOfStoreFronts[i].Name == p_value)
                        {
                            listOfSearchedStoreFronts.Add(listOfStoreFronts[i]);
                        }
                    }
                    return listOfSearchedStoreFronts;
                case "address":
                    foreach(StoreFronts s in listOfStoreFronts)
                    {
                        if (s.Address == p_value)
                        {
                            listOfSearchedStoreFronts.Add(s);
                        }
                    }
                    return listOfSearchedStoreFronts;
                case "city":
                    foreach(StoreFronts s in listOfStoreFronts)
                    {
                        if (s.City == p_value)
                        {
                            listOfSearchedStoreFronts.Add(s);
                        }
                    }
                    return listOfSearchedStoreFronts;
                case "state":
                    foreach(StoreFronts s in listOfStoreFronts)
                    {
                        if (s.State == p_value)
                        {
                            listOfSearchedStoreFronts.Add(s);
                        }
                    }
                    return listOfSearchedStoreFronts;
                default:
                    return listOfSearchedStoreFronts;
            }
        }

        //------------------------------------------- JSON -------------------------------------------
        //private const string _filePath = "./../SSDDL/DataBase/StoreFronts.json";
        // private string _jsonString;
        // public List<StoreFronts> GetAllStoreFronts()
        // {
        //     try
        //     {
        //         _jsonString = File.ReadAllText(_filePath);
        //     }
        //     catch (System.Exception)
        //     {
        //         throw new System.Exception("File path is invalid");
        //     }

        //     return JsonSerializer.Deserialize<List<StoreFronts>>(_jsonString);
        // }
    }
}