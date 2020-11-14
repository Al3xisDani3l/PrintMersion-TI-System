using PrintMersion.Core.Interfaces;

namespace PrintMersion.Core.Entities
{
    public partial class ProductsPictures: IEntity
    {

        public int Id { get; set; }
        public int IdProduct { get; set; }
        public int IdPicture { get; set; }

        public virtual Picture IdPictureNavigation { get; set; }
        public virtual Product IdProductNavigation { get; set; }
    }
}
