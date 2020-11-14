using PrintMersion.Core.Interfaces;
using System.Collections.Generic;
using System.Drawing;

namespace PrintMersion.Core.Entities
{
    public class Picture : IEntity
    {
        public Picture()
        {
            Users = new HashSet<User>();
           
        }

        public int Id { get; set; }
        public string Metadata { get; set; }
        public string DataRaw { get; set; }

        public virtual ICollection<User> Users
        {
            get; set;
        }
    }
}
