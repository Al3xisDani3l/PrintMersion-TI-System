using System;
using System.Collections.Generic;

namespace Scaffolding.Data
{
    public partial class CatalogsPictures
    {
        public int IdCatalog { get; set; }
        public int IdPicture { get; set; }

        public virtual Catalog IdCatalogNavigation { get; set; }
        public virtual Pictures IdPictureNavigation { get; set; }
    }
}
