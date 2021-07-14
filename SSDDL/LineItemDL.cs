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

        public List<LineItems> GetAnOrderLineItems(Orders p_order)
        {
            // var queryResult = (from li in _context.LineItems
            //                     where li.OrderId == p_order.Id
            //                     select li).ToList();
            
            // _context.LineItems.Where(li => li.OrderId == p_order.Id).ToList();

            List<LineItems> listOfAllLineItems = this.GetAllLineItems();
            List<LineItems> returnedList = new List<LineItems>();
            foreach (LineItems li in listOfAllLineItems)
            {
                if(li.OrderId == p_order.Id)
                {
                    returnedList.Add(li);
                }
            }
            return returnedList;
            
        }

        public List<LineItems> GetAnOrderLineItems(int p_orderID)
        {
            List<LineItems> listOfAllLineItems = this.GetAllLineItems();
            List<LineItems> returnedList = new List<LineItems>();
            foreach (LineItems li in listOfAllLineItems)
            {
                if(li.OrderId == p_orderID)
                {
                    returnedList.Add(li);
                }
            }
            return returnedList;
            
        }
    }
}