using System;
using System.Collections.Generic;

#nullable disable

namespace SSDDL.Entities
{
    public partial class Finger
    {
        public int? FingerLength { get; set; }
        public string FingerType { get; set; }
        public int? PersonSsn { get; set; }

        public virtual Person PersonSsnNavigation { get; set; }
    }
}
