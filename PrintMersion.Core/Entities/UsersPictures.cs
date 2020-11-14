using PrintMersion.Core.Interfaces;

namespace PrintMersion.Core.Entities
{
    public partial class UsersPictures: IEntity
    {
        public int Id { get; set; }
        public int IdUser { get; set; }
        public int IdPicture { get; set; }

        public virtual User IdUserNavigation { get; set; }
        public virtual Picture IdPictureNavigation { get; set; }
    }
}
