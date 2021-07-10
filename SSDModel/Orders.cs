using System;
using System.Collections.Generic;
namespace SSDModel
{
    public class Orders 
    {
        private int _id;
        private int _customerId;
        private int _storeFrontId;
        private double _totalPrice;

        public Orders()
        {
        }
               
        public int Id { get => _id; set => _id = value; }
        public int CustomerId { get => _customerId; set => _customerId = value; }
        public int StoreFrontId { get => _storeFrontId; set => _storeFrontId = value; }
        public double TotalPrice1 { get => _totalPrice; set => _totalPrice = value; }
        public double TotalPrice { get => OrderTotal(); set => TotalPrice1 = OrderTotal();}

        public double OrderTotal()
        {
            double total = 0.0;
            return total;
        }
        

        // public override string ToString()
        // {
        //     string tempString = "Location: " + _location.Name + _location.Address + "\n";
        //     for (int i = 0; i < _listOfLineItems.Count; i++)
        //     {
        //         tempString += _listOfLineItems[i].ToString() + "\n";
        //     }
        //     tempString += "Order Total is: $" + OrderTotal();
        //     return tempString;
        // }
    }
}