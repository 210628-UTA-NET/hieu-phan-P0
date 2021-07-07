using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using SSDModel;

namespace SSDDL
{
    public class StoreFrontRepository : IStoreFrontRepository
    {
        private const string _filePath = "./../SSDDL/DataBase/StoreFronts.json";
        private string _jsonString;
        public List<StoreFronts> GetAllStoreFronts()
        {
            try
            {
                _jsonString = File.ReadAllText(_filePath);
            }
            catch (System.Exception)
            {
                throw new System.Exception("File path is invalid");
            }

            return JsonSerializer.Deserialize<List<StoreFronts>>(_jsonString);
        }

        public List<StoreFronts> SearchStoreFront(string p_criteria, string p_value)
        {
            List<StoreFronts> listOfStoreFronts = this.GetAllStoreFronts();
            List<StoreFronts> listOfSearchedStoreFronts = new List<StoreFronts>();
            switch(p_criteria)
            {
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
                        else
                        {
                            listOfSearchedStoreFronts = null;
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
                        else
                        {
                            listOfSearchedStoreFronts = null;
                        }
                    }
                    return listOfSearchedStoreFronts;
                default:
                    listOfSearchedStoreFronts = null;
                    return listOfSearchedStoreFronts;
            }
        }
    }
}