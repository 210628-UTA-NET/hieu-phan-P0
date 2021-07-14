using System;

namespace SSDModel
{
    public class Products
    {
        private int _id;
        private string _name;
        private double _price;
        private string _description;
        private string _category;

        public Products()
        {
        }

        public int Id { get => _id; set => _id = value; }
        public string Name { get => _name; set => _name = value; }
        public double Price { get => _price; set => _price = value; }
        public string Description { get => _description; set => _description = value; }
        public string Category { get => _category; set => _category = value; }
        

        public override string ToString()
        {
            // return $"Product ID: {Id} ||| Product: {Name} ||| Price: ${Price} ||| Description: {Description} ||| Category: {Category} |||";
            return $"Product ID: {Id} ||| Product: {Name} ||| Price: $" + string.Format("{0:0.00}",Price) + $" ||| Description: {Description} ||| Category: {Category} |||";
        }
    }
}