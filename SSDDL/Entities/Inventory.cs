using System;
using System.Collections.Generic;

#nullable disable

namespace SSDDL.Entities
{
    public partial class Inventory
    {
        public int Id { get; set; }
        public int StoreFrontId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }

        public virtual Product Product { get; set; }
        public virtual StoreFront StoreFront { get; set; }
    }
}
