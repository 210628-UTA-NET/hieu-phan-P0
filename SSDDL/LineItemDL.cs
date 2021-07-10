using System.Collections.Generic;
using SSDModel;

namespace SSDDL
{
    public class LineItemDL : ILineItemDL
    {
        private Entities.DemoDbContext _context;
        public LineItemDL (Entities.DemoDbContext p_context)
        {
            _context = p_context;
        }

        public List<LineItems> GetAllLineItems()
        {
            throw new System.NotImplementedException();
        }
    }
}