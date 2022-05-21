using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common
{
    public class AuditableEntity
    {
        public DateTime DateEntered { get; set; }
        public DateTime DateLastUpdated { get; set; }
    }
}
