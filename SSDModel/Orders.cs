using System;
using System.Collections.Generic;
namespace SSDModel
{
    public class Orders 
    {
        private List<LineItems> _orderLineItems = new List<LineItems>();
        private string _location;
        // private double _totalPrice;

        public Orders(List<LineItems> orderLineItems, string location)
        {
            OrderLineItems = orderLineItems;
            Location = location;
        }

        public Orders()
        {
        }
        
        public List<LineItems> OrderLineItems { get => _orderLineItems; set => _orderLineItems = value; }
        public string Location { get => _location; set => _location = value; }
        public double TotalPrice { get => OrderTotal(); }

        public double OrderTotal()
        {
            double total = 0.0;
            for (int i = 0; i < _orderLineItems.Count; i++)
            {
                total += _orderLineItems[i].LineTotal();
            }
            return total;
        }
        

        public override string ToString()
        {
            string tempString = "Location: " + _location + "\n";
            for (int i = 0; i < _orderLineItems.Count; i++)
            {
                tempString += _orderLineItems[i].ToString() + "\n";
            }
            tempString += "Order Total is: $" + OrderTotal();
            return tempString;
        }
    }
}