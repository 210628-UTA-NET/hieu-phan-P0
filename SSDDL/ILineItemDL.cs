using System.Collections.Generic;
using SSDModel;

namespace SSDDL
{
    public interface ILineItemDL
    {
        List<LineItems> GetAllLineItems();
        List<LineItems> GetAnOrderLineItems(Orders p_order);
        LineItems AddALineItem(LineItems p_lineItem);
    }
}