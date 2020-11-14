using PrintMersion.Core.Interfaces;

namespace PrintMersion.Core.Entities
{
    public partial class ToolsPictures:IEntity
    {
        public int Id { get; set; }
        public int IdTools { get; set; }
        public int IdPicture { get; set; }

        public virtual Picture IdPictureNavigation { get; set; }
        public virtual Tool IdToolsNavigation { get; set; }
    }
}
