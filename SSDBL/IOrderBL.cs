using System.Collections.Generic;
using SSDModel;

namespace SSDBL
{
    public interface IOrderBL
    {
        List<Orders> GetAllOrders();
        Orders AddAnOrder(Orders p_order);

        List<Orders> SearchOrders(string p_criteria, string p_value);

    }
}