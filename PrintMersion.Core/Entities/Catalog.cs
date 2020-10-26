using PrintMersion.Core.Interfaces;

namespace PrintMersion.Core.Entities
{
    public class Catalog : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
