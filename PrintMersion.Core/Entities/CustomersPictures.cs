using System;
using System.Collections.Generic;

namespace PrintMersion.Core.Entities
{
    public partial class CustomersPictures
    {
        public int IdCustomer { get; set; }
        public int IdPicture { get; set; }

        public virtual Customer IdCustomerNavigation { get; set; }
        public virtual Picture IdPictureNavigation { get; set; }
    }
}
