using PrintMersion.Core.Interfaces;
namespace PrintMersion.Core.DTOs
{
    public class PictureDto : IEntity
    {
        public int Id { get; set; }
        public string Metadata { get; set; }
        public string DataRaw { get; set; }
    }
}
