using System;
using System.Collections.Generic;
using System.Text;

namespace PrintMersion_Models.Entities
{
    public class Order
    {
        public int Id { get; set; }

        public DateTime Delivery { get; set; }

        public DateTime OrderDate { get; set; }

        public Guid Guid { get; set; }

        public IEnumerable<string> Files { get; set; }

 

        public IEnumerable<string> ImagesOfFile { get; set; }

        public Guid Client { get; set; }

        public Guid Payment { get; set; }





    }
}
