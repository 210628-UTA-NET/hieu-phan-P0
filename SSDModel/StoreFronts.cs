using System;
using System.Collections.Generic;

namespace SSDModel
{
    public class StoreFronts {
        private string _name;
        private string _address;
        private List<Products> _inventory = new List<Products>();
        public StoreFronts()
        {
            
        }

        public string Name { get => _name; set => _name = value; }
        public string Address { get => _address; set => _address = value; }
        public List<Products> Inventory { get => _inventory; }

        public void Add(Products _item) {
            _inventory.Add(_item);
        }

        // need to create a remove method
    }
}