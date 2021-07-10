using System.Collections.Generic;
using SSDModel;
using System.Linq;

namespace SSDDL
{
    public class InventoryDL : IInventoryDL
    {
        private Entities.DemoDbContext _context;
        public InventoryDL (Entities.DemoDbContext p_context)
        {
            _context = p_context;
        }
        public List<Inventories> GetAllInventories()
        {
            return _context.Inventories.Select(
                inv =>
                    new Inventories()
                    {
                        Id = inv.Id,
                        StoreFrontId = inv.StoreFrontId,
                        ProductId = inv.ProductId,
                        Quantity = inv.Quantity
                    }
            ).ToList();
        }
    }
}