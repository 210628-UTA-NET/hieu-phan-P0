using System;
using System.Collections.Generic;

#nullable disable

namespace SSDDL.Entities
{
    public partial class Review
    {
        public int Id { get; set; }
        public decimal? Rating { get; set; }
        public string ReviewDescripton { get; set; }
        public int? RestaurantId { get; set; }

        public virtual Restaurant Restaurant { get; set; }
    }
}
