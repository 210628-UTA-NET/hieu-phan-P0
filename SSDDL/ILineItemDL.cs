using System.Collections.Generic;
using SSDModel;

namespace SSDDL
{
    public interface ILineItemDL
    {
        List<LineItems> GetAllLineItems();
        List<LineItems> GetAnOrderLineItems(Orders p_order);
        List<LineItems> GetAnOrderLineItems(int p_orderID);
        LineItems AddALineItem(LineItems p_lineItem);
    }
}