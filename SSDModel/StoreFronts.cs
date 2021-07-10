using System;
using System.Collections.Generic;

namespace SSDModel
{
    public class StoreFronts {
        private int _id;
        private string _name;
        private string _address;
        private string _city;
        private string _state;
        public StoreFronts()
        {           
        }

        public int Id { get => _id; set => _id = value; }
        public string Name { get => _name; set => _name = value; }
        public string Address { get => _address; set => _address = value; }
        public string City { get => _city; set => _city = value; }
        public string State { get => _state; set => _state = value; }

        public override string ToString()
        {
            
            return $"Id:[{Id}] Name: {Name} ||| Address: {Address} ||| City: {City} ||| State: {State}";
        }

        // public string DisplayInventory()
        // {
        //     string inventoryString = "";
        //     for(int i = 0; i < Inventory.Count; i++)
        //     {
        //         inventoryString += "\n" + "[" + i + "] " + Inventory[i].Keys.ToString() + " Quantity : " + Inventory[i].Values;
        //     }

        //     return inventoryString;
        // }
    }
}