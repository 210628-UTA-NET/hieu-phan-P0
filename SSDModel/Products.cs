using System;

namespace SSDModel
{
    public class Products
    {
        private string _name;
        private double _price;
        private string _description;
        private string _category;

        public Products()
        {
            
        }
        public Products(string p_name, double p_price)
        {
            Name = p_name;
            Price = p_price;
            Description = "";
            Category = "";
        }

        public Products(string p_name, double p_price, string p_description, string p_category)
        {
            Name = p_name;
            Price = p_price;
            Description = p_description;
            Category = p_category;
        }

        public string Name { get => _name; set => _name = value; }
        public double Price { get => _price; set => _price = value; }
        public string Description { get => _description; set => _description = value; }
        public string Category { get => _category; set => _category = value; }

        public override string ToString()
        {
            return "Product: " + _name + " $" + _price + "\nDescription: " + _description + "\nCategory: " + _category;
        }
    }
}