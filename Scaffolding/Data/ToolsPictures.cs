using System;
using System.Collections.Generic;

namespace Scaffolding.Data
{
    public partial class ToolsPictures
    {
        public int IdTools { get; set; }
        public int IdPicture { get; set; }

        public virtual Pictures IdPictureNavigation { get; set; }
        public virtual Tools IdToolsNavigation { get; set; }
    }
}
