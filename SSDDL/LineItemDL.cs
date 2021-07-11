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

        public LineItems AddALineItem(LineItems p_lineItem)
        {
            _context.LineItems.Add(new Entities.LineItem{
                OrderId = p_lineItem.OrderId,
                ProductId = p_lineItem.ProductId,
                Quantity = p_lineItem.Quantity
            });

            _context.SaveChanges();
            return p_lineItem;
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