namespace PrintMersion.Core.Entities
{
    public partial class CatalogsProducts
    {
        public int IdProduct { get; set; }
        public int IdCatalog { get; set; }

        public virtual Catalog IdCatalogNavigation { get; set; }
        public virtual Product IdProductNavigation { get; set; }
    }
}
