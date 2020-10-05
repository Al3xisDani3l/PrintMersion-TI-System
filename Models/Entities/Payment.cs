using System;
using System.Collections.Generic;
using System.Text;

namespace PrintMersion_Models.Entities
{
  public class Payment
    {
        public int Id { get; set; }
        public decimal? AproximateCost { get; set; }
        public Guid Guid { get; set; }
        public DateTime Date { get; set; }
        public decimal? RealCost { get; set; }
        public decimal? Discount { get; set; }
        public decimal? TotalCost { get; set; }

        public bool? Acquitted { get; set; }

        





    }
}
