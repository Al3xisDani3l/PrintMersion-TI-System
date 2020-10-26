using PrintMersion.Core.Interfaces;
namespace PrintMersion.Core.DTOs
{
    public class CatalogDto : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
