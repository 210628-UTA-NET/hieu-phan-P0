using System.Collections.Generic;
using SSDModel;

namespace SSDDL
{
    public interface IOrderDL
    {
        List<Orders> GetAllOrders();

        Orders AddAnOrder(Orders p_order);

        List<Orders> SearchOrders(string p_criteria, string p_value);
    }
}