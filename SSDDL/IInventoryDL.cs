using System.Collections.Generic;
using SSDModel;

namespace SSDDL
{
    public interface IInventoryDL
    {
        List<Inventories> GetAllInventories();

        Inventories UpdateInventoryQuantity(Inventories p_inv, int p_quantity);
    }
}