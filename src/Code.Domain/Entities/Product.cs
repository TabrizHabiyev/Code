using Code.Domain.Common;

namespace Code.Domain.Entity
{
    public class Product : BaseAuditableEntity
    {
        public string ProductName { get; set; } = null!;
        public decimal UnitPrice { get; set; }
        public short UnitInStock { get; set; }
        public int? CategoryId { get; set; }
        public virtual Category? Category { get; set; }
    }
}
