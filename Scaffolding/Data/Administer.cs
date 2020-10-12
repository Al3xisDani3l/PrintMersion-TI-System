using System;
using System.Collections.Generic;

namespace Scaffolding.Data
{
    public partial class Administer
    {
        public Administer()
        {
            LogsTools = new HashSet<LogsTools>();
            Orders = new HashSet<Orders>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public virtual ICollection<LogsTools> LogsTools { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }
    }
}
