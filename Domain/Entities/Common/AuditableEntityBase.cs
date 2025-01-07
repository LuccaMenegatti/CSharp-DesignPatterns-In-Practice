namespace AtividadeEmGrupoP2.Domain.Entities.Common;

public class AuditableEntityBase<T> : EntityBase<T>, IAuditableEntity
{
    public DateTime Created { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? LastModified { get; set; }
    public string? LastModifiedBy { get; set; }

    public void OnAuditInsert(string user, DateTime dateTimeNow)
    {
        CreatedBy = string.IsNullOrEmpty(CreatedBy) ? user : CreatedBy;
        Created = dateTimeNow;
    }

    public void OnAuditUpdate(string user, DateTime dateTimeNow)
    {
        LastModifiedBy = user;
        LastModified = dateTimeNow;
    }
}
