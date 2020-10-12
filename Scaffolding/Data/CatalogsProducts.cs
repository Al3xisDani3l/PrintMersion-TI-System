using System;
using System.Collections.Generic;

namespace Scaffolding.Data
{
    public partial class CatalogsProducts
    {
        public int IdProduct { get; set; }
        public int IdCatalog { get; set; }

        public virtual Catalog IdCatalogNavigation { get; set; }
        public virtual Products IdProductNavigation { get; set; }
    }
}
