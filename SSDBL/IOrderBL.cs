using System.Collections.Generic;
using SSDModel;

namespace SSDBL
{
    public interface IOrderBL
    {
        List<Orders> GetAllOrders();
        Orders AddAnOrder(Orders p_order);

    }
}