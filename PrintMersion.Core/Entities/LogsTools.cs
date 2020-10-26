using PrintMersion.Core.Interfaces;
using System;

namespace PrintMersion.Core.Entities
{
    public class LogsTools : IEntity
    {
        public int Id { get; set; }
        public int IdTool { get; set; }
        public int IdAdminister { get; set; }
        public DateTime StartUse { get; set; }
        public DateTime EndUse { get; set; }

        public virtual Administer IdAdministerNavigation { get; set; }
        public virtual Tool IdToolNavigation { get; set; }
    }
}
