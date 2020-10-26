using PrintMersion.Core.Interfaces;
namespace PrintMersion.Core.Entities
{
    public class Picture : IEntity
    {
        public int Id { get; set; }
        public string Metadata { get; set; }
        public string DataRaw { get; set; }
    }
}
