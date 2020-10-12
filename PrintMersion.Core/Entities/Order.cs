using System;
using System.Collections.Generic;

namespace PrintMersion.Core.Entities
{
    public  class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public int? Address { get; set; }
        public double Subtotal { get; set; }
        public double Total { get; set; }
        public string DeliveryMethod { get; set; }
        public string DetailedInformation { get; set; }
        public Guid Tracking { get; set; }
        public string Status { get; set; }
        public string PaymentMethod { get; set; }
        public int IdCustomer { get; set; }
        public int? IdAdminister { get; set; }

        public virtual Administer IdAdministerNavigation { get; set; }
        public virtual Customer IdCustomerNavigation { get; set; }
    }
}
