using System;
using System.Collections.Generic;

#nullable disable

namespace SSDDL.Entities
{
    public partial class PersonsCourse
    {
        public int? PersonSsn { get; set; }
        public int? CourseId { get; set; }

        public virtual Course Course { get; set; }
        public virtual Person PersonSsnNavigation { get; set; }
    }
}
