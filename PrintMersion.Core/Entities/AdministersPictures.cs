using System;
using System.Collections.Generic;

namespace PrintMersion.Core.Entities
{
    public partial class AdministersPictures
    {
        public int IdAdministers { get; set; }
        public int IdPicture { get; set; }

        public virtual Administer IdAdministersNavigation { get; set; }
        public virtual Picture IdPictureNavigation { get; set; }
    }
}
