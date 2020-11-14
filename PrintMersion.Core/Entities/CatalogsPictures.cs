﻿using PrintMersion.Core.Interfaces;
namespace PrintMersion.Core.Entities
{
    public partial class CatalogsPictures : IEntity
    {
        public int Id { get; set; }
        public int IdCatalog { get; set; }
        public int IdPicture { get; set; }

        public virtual Catalog IdCatalogNavigation { get; set; }
        public virtual Picture IdPictureNavigation { get; set; }
    }
}
