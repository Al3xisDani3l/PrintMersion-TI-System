using PrintMersion.Core.Interfaces;

namespace PrintMersion.Core.Entities
{
    public partial class CustomersPictures: IEntity
    {
        public int Id { get; set; }
        public int IdCustomer { get; set; }
        public int IdPicture { get; set; }

        public virtual Customer IdCustomerNavigation { get; set; }
        public virtual Picture IdPictureNavigation { get; set; }
    }
}
