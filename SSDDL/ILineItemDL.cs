using System.Collections.Generic;
using SSDModel;

namespace SSDDL
{
    public interface ILineItemDL
    {
        List<LineItems> GetAllLineItems();
        LineItems AddALineItem(LineItems p_lineItem);
    }
}