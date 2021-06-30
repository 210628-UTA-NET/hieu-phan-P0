using System;
namespace SSDModel
{
    public class LineItems
    {
        private string _product;
        private int _quantity;
        private double _price;

        public LineItems()
        {
            
        }

        public LineItems(string product, int quantity, double price)
        {
            Product = product;
            Quantity = quantity;
            Price = price;
        }

        public string Product { get => _product; set => _product = value; }
        public int Quantity { get => _quantity; set => _quantity = value; }
        public double Price { get => _price; set => _price = value; }

        public double LineTotal()
        {
            return _quantity*_price;
        }

        public override string ToString()
        {
            return "Product: " + _product + " | Quantity: " + _quantity + " | Price: $" + _price + " | Line Total: $" + LineTotal();
        }
    }
}