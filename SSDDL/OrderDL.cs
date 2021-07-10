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
        public List<Orders> GetAllOrders()
        {
            return _context.Orders.Select(
                or =>
                    new Orders()
                    {
                        Id = or.Id,
                        CustomerId = or.CustomerId,
                        StoreFrontId = or.StoreFrontId,
                        TotalPrice = (double)or.TotalPrice
                    }
            ).ToList();
        }
    }
}