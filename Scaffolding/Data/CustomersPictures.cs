using System;
using System.Collections.Generic;

namespace Scaffolding.Data
{
    public partial class CustomersPictures
    {
        public int IdCustomer { get; set; }
        public int IdPicture { get; set; }

        public virtual Customers IdCustomerNavigation { get; set; }
        public virtual Pictures IdPictureNavigation { get; set; }
    }
}
