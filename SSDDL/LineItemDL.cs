using System.Collections.Generic;
using SSDModel;
using System.Linq;

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
            return _context.LineItems.Select(
                li =>
                    new LineItems()
                    {
                        Id = li.Id,
                        OrderId = li.OrderId,
                        ProductId = li.ProductId,
                        Quantity = li.Quantity
                    }
            ).ToList();
        }
    }
}