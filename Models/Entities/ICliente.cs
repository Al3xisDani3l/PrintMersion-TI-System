using System;
using System.Collections.Generic;
using System.Text;

namespace PrintMersion_Models.Entities
{
  public  interface ICliente
    {

        int Id { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public Guid Guid { get; set; }

        public string Mail { get; set; }

        public IEnumerable<Order> Orders { get; set; }
    }
}
