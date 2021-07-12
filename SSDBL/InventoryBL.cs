using System.Collections.Generic;
using SSDModel;
using SSDDL;

namespace SSDBL
{
    public class InventoryBL : IInventoryBL
    {
        private IInventoryDL _repo;
        public InventoryBL(IInventoryDL p_repo)
        {
            _repo = p_repo;
        }

        public void AddNewProductInventory(int p_sfId, int p_productId, int quantity)
        {
            _repo.AddNewProductInventory(p_sfId, p_productId, quantity);
        }

        public void ReplenishInventory(int p_sfId, int p_productId, int p_quantity)
        {
            _repo.ReplenishInventory(p_sfId, p_productId, p_quantity);
        }
        public List<Inventories> GetAllInventories()
        {
            return _repo.GetAllInventories();
        }


        public Inventories UpdateInventoryQuantity(Inventories p_inv, int p_quantity)
        {
            return _repo.UpdateInventoryQuantity(p_inv, p_quantity);
        }
    }
}