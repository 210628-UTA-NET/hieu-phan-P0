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

        public Inventories UpdateInventoryQuantity(Inventories p_inv, int p_quantity)
        {
            var theInv = (from invt in _context.Inventories
                                where invt.Id == p_inv.Id
                                select invt).First();
            theInv.Quantity = p_quantity;

            _context.SaveChanges();

            List<Inventories> listOfInventory = GetAllInventories();
            Inventories inv = new Inventories();
            foreach(Inventories i in listOfInventory)
            {
                if(i.Id == p_inv.Id)
                {
                    inv = i;
                }
            }
            return inv;
        }
    }
}