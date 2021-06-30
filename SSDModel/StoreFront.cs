using System;
using System.Collections.Generic;

namespace SSDModel
{
    public class StoreFront {
        private string _name;
        private string _address;
        private List<string> _inventory = new List<string>();
        public StoreFront()
        {
            
        }

        public string Name { get => _name; set => _name = value; }
        public string Address { get => _address; set => _address = value; }
        public List<string> Inventory { get => _inventory; }

        public void Add(string item) {
            _inventory.Add(item);
        }

        // need to create a remove method
    }
}