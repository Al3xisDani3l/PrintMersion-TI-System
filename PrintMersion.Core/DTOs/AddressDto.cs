using System;
using System.Collections.Generic;

namespace PrintMersion.Core.DTOs
{
    public class AddressDto
    {
        

     
        public string Street { get; set; }
        public string InteriorNumber { get; set; }
        public string ExteriorNumber { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }

        
    }
}
