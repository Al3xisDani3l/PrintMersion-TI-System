using Microsoft.EntityFrameworkCore;
using PrintMersion.Core.Entities;

namespace PrintMersion.Core.Interfaces
{
    public interface IDBContextModel
    {
        DbSet<Address> Address { get; set; }
        DbSet<Administer> Administers { get; set; }
        DbSet<AdministersPictures> AdministersPictures { get; set; }
        DbSet<Catalog> Catalogs { get; set; }
        DbSet<CatalogsPictures> CatalogsPictures { get; set; }
        DbSet<CatalogsProducts> CatalogsProducts { get; set; }
        DbSet<Customer> Customers { get; set; }
        DbSet<CustomersPictures> CustomersPictures { get; set; }
        DbSet<LogsTools> LogsTools { get; set; }
        DbSet<Order> Orders { get; set; }
        DbSet<Picture> Pictures { get; set; }
        DbSet<Product> Products { get; set; }
        DbSet<ProductsPictures> ProductsPictures { get; set; }
        DbSet<Tool> Tools { get; set; }
        DbSet<ToolsPictures> ToolsPictures { get; set; }
    }
}
