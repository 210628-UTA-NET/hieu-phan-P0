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

        public List<LineItems> GetAllLineItems()
        {
            return _repo.GetAllLineItems();
        }

    }
}