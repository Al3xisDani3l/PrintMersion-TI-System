namespace PrintMersion.Core.Entities
{
    public partial class ToolsPictures
    {
        public int IdTools { get; set; }
        public int IdPicture { get; set; }

        public virtual Picture IdPictureNavigation { get; set; }
        public virtual Tool IdToolsNavigation { get; set; }
    }
}
