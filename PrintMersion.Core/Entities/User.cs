using PrintMersion.Core.Interfaces;
using System.Collections.Generic;
using PrintMersion.Core.Enumerations;
namespace PrintMersion.Core.Entities
{
    public class User : IEntity
    {
        public User()
        {
            LogsTools = new HashSet<LogsTools>();
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int? IdPicture { get; set; }
        public RoleType Role { get; set; }

        public virtual Picture IdPictureNavigation { get; set; }
        public virtual ICollection<LogsTools> LogsTools { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
