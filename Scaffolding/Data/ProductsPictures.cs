using System;
using System.Collections.Generic;

namespace Scaffolding.Data
{
    public partial class ProductsPictures
    {
        public int IdProduct { get; set; }
        public int IdPicture { get; set; }

        public virtual Pictures IdPictureNavigation { get; set; }
        public virtual Products IdProductNavigation { get; set; }
    }
}
