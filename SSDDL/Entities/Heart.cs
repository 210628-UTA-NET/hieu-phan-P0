using System;
using System.Collections.Generic;

#nullable disable

namespace SSDDL.Entities
{
    public partial class Heart
    {
        public int? HeartSize { get; set; }
        public bool? Healthy { get; set; }
        public int? PersonSsn { get; set; }

        public virtual Person PersonSsnNavigation { get; set; }
    }
}
