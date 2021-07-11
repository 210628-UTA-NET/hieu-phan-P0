using System.Collections.Generic;
using SSDModel;
using SSDDL;

namespace SSDBL
{
    public class LineItemBL : ILineItemBL
    {
        private ILineItemDL _repo;
        public LineItemBL(ILineItemDL p_repo)
        {
            _repo = p_repo;
        }

        public LineItems AddALineItem(LineItems p_lineItem)
        {
            return _repo.AddALineItem(p_lineItem);
        }

        public List<LineItems> GetAllLineItems()
        {
            return _repo.GetAllLineItems();
        }

    }
}