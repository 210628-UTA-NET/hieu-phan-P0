using System.Collections.Generic;
using SSDModel;
using SSDDL;

namespace SSDBL
{
    public class OrderBL : IOrderBL
    {
        private IOrderDL _repo;
        public OrderBL(IOrderDL p_repo)
        {
            _repo = p_repo;
        }

        public Orders AddAnOrder(Orders p_order)
        {
            return _repo.AddAnOrder(p_order);
        }

        public List<Orders> GetAllOrders()
        {
            return _repo.GetAllOrders();
        }

    }
}