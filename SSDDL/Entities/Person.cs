using System;
using System.Collections.Generic;

#nullable disable

namespace SSDDL.Entities
{
    public partial class Person
    {
        public int Ssn { get; set; }
        public string PersonName { get; set; }
        public int? PersonAge { get; set; }
    }
}
