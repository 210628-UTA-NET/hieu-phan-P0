using System.Collections.Generic;
using SSDModel;

namespace SSDBL
{
    public interface ILineItemBL
    {
        List<LineItems> GetAllLineItems();
        List<LineItems> GetAnOrderLineItems(Orders p_order);
        LineItems AddALineItem(LineItems p_lineItem);
    }
}