using System;
using System.Collections.Generic;

namespace PrintMersion.Core.Entities
{
    public partial class CatalogsPictures
    {
        public int IdCatalog { get; set; }
        public int IdPicture { get; set; }

        public virtual Catalog IdCatalogNavigation { get; set; }
        public virtual Picture IdPictureNavigation { get; set; }
    }
}
