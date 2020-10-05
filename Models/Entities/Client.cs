using System;
using System.Collections.Generic;
using System.Text;

namespace PrintMersion_Models.Entities
{
   public class Client:ICliente
    {

        public string Name { get; set; }

        public string LastName { get; set; }

        public Guid Guid { get; set; }

        public string Mail { get; set; }

        public IEnumerable<Order> Orders { get; set; }




    }

  



}
