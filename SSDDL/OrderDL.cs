using System.Collections.Generic;
using SSDModel;
using System.Linq;

namespace SSDDL
{
    public class OrderDL : IOrderDL
    {
        private Entities.DemoDbContext _context;
        public OrderDL (Entities.DemoDbContext p_context)
        {
            _context = p_context;
        }

        public Orders AddAnOrder(Orders p_order)
        {
            _context.Orders.Add(new Entities.Order{
                CustomerId = p_order.CustomerId,
                StoreFrontId = p_order.StoreFrontId,
                TotalPrice = (decimal)p_order.TotalPrice
            });
            _context.SaveChanges();

            var theOrder = (from ord in _context.Orders
                            orderby ord.Id
                            where ord.CustomerId == p_order.CustomerId &&
                                    ord.StoreFrontId == p_order.StoreFrontId &&
                                    ord.TotalPrice == (decimal)p_order.TotalPrice
                            select ord).Last();
            p_order.Id = theOrder.Id;
            return p_order;
        }

        public List<Orders> GetAllOrders()
        {
            return _context.Orders.Select(
                order =>
                    new Orders()
                    {
                        Id = order.Id,
                        CustomerId = order.CustomerId,
                        StoreFrontId = order.StoreFrontId,
                        TotalPrice = (double)order.TotalPrice
                    }
            ).ToList();
        }

        public List<Orders> SearchOrders(string p_criteria, string p_value)
        {
            List<Orders> listOfOrders = this.GetAllOrders();
            List<Orders> listOfSearchedOrders = new List<Orders>();
            int value = int.Parse(p_value);
            switch(p_criteria)
            {
                case "id":
                foreach (Orders o in listOfOrders)
                {
                    if(o.Id == value)
                    {
                        listOfSearchedOrders.Add(o);
                    }
                }
                return listOfSearchedOrders;
                case "customerID":
                foreach (Orders o in listOfOrders)
                {
                    if(o.CustomerId == value)
                    {
                        listOfSearchedOrders.Add(o);
                    }
                }
                return listOfSearchedOrders;
                case "storeFrontID":
                foreach (Orders o in listOfOrders)
                {
                    if(o.StoreFrontId == value)
                    {
                        listOfSearchedOrders.Add(o);
                    }
                }
                return listOfSearchedOrders;
                default:
                return listOfSearchedOrders;
            }
        }
    }
}