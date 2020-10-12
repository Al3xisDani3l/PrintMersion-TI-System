using System;
using System.Collections.Generic;

namespace Scaffolding.Data
{
    public partial class AdministersPictures
    {
        public int IdAdministers { get; set; }
        public int IdPicture { get; set; }

        public virtual Administer IdAdministersNavigation { get; set; }
        public virtual Pictures IdPictureNavigation { get; set; }
    }
}
