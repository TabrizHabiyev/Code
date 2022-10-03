using Code.Domain.Common;

namespace Code.Domain.Entity
{
    public class Category : BaseAuditableEntity
    {
        public Category()
        {
             this.Products = new HashSet<Product>();
        }
        public string CategoryName { get; set; } = null!;
        public string? Description { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
