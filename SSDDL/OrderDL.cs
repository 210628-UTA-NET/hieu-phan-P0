using System.Collections.Generic;
using SSDModel;

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
            throw new System.NotImplementedException();
        }
    }
}