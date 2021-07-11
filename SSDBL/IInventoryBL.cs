using System.Collections.Generic;
using SSDModel;

namespace SSDBL
{
    public interface IInventoryBL
    {
        List<Inventories> GetAllInventories();

        Inventories UpdateInventoryQuantity(Inventories p_inv, int p_quantity);

    }
}