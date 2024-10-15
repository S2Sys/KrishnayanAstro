using KrishnyanAstro.Shared.Interfaces;

namespace KrishnyanAstro.Shared.BaseClasses
{
    public abstract class AuditableEntity : BaseEntity, IAuditableEntity
    {
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? LastModifiedAt { get; set; }
        public string LastModifiedBy { get; set; }
    }
}
