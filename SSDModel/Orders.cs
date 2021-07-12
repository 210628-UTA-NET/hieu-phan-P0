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
        public double TotalPrice { get => _totalPrice; set => _totalPrice = value; }

        public override string ToString()
        {
            return $"Order ID: [{Id}] ||| CustomerID: {CustomerId} ||| StoreFrontID: {StoreFrontId} ||| Total Price: ${TotalPrice}";
        }
    }
}