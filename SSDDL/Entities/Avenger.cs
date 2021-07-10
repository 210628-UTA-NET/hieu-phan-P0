using System;
using System.Collections.Generic;

#nullable disable

namespace SSDDL.Entities
{
    public partial class Avenger
    {
        public string SuperheroName { get; set; }
        public string SuperheroPower { get; set; }
        public string RealName { get; set; }
        public int? PowerLevel { get; set; }
    }
}
