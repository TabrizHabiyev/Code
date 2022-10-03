namespace Code.Domain.Common
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
    }

    public abstract class BaseAuditableEntity:BaseEntity
    {
        public DateTime CreateDate { get; set; }
        public string? CreateBy  { get; set; }
        public  DateTime? LastModified { get; set; }
        public string? LastModifiedBy { get; set; }
    }
}
