using System.Collections.Generic;
using SSDModel;

namespace SSDDL
{
    public interface IOrderDL
    {
        List<Orders> GetAllOrders();

        Orders AddAnOrder(Orders p_order);
    }
}