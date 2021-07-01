﻿using System;
using System.Collections.Generic;
namespace SSDModel
{
    public class Customers{
        private string _name;
        private string _address;
        private string _email;
        private string _phone;
        private List<Orders> _listOfOrders = new List<Orders>();

        

        public Customers(string p_name, string p_address, string p_email, string p_phone)
        {
            Name = p_name;
            Address = p_address;
            Email = p_email;
            Phone = p_phone;
        }

        public Customers()
        {
        }

        public string Name { get => _name; set => _name = value; }
        public string Address { get => _address; set => _address = value; }
        public string Email { get => _email; set => _email = value; }
        public string Phone { get => _phone; set => _phone = value; }
        public List<Orders> ListOfOrders { get => _listOfOrders; }

        public override string ToString()
        {
            // return "Customer: " + _name + " | " + _address + " | " + _email + " | " + _phone + "\nNumber of order: " + ListOfOrders.Count;
            return $"Name: {Name}, Address: {Address}, Email: {Email}, Phone: {Phone}";
        }

        public void AddToListOfOrders(Orders p_order)
        {
            ListOfOrders.Add(p_order);
        }
        
    }
}
