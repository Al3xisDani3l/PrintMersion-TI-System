using System;
using System.Collections.Generic;

namespace Scaffolding.Data
{
    public partial class LogsTools
    {
        public int Id { get; set; }
        public int IdTool { get; set; }
        public int IdAdminister { get; set; }
        public DateTime StartUse { get; set; }
        public DateTime EndUse { get; set; }

        public virtual Administer IdAdministerNavigation { get; set; }
        public virtual Tools IdToolNavigation { get; set; }
    }
}
