using AtividadeEmGrupoP2.Domain.Entities.Common;

namespace AtividadeEmGrupoP2.Domain.Builders;

public abstract class QueryBuilderBase<TBuilder, TEntity, TRequest> where TEntity : AuditableEntityBase<Guid>
{
    protected static TBuilder _instance { get; set; }
    protected IQueryable<TEntity> Query { get; set; }
    protected TRequest Request { get; set; }
    public bool IsOrdered { get; set; } = false;

    public void SetIsOrdered()
    {
        IsOrdered = true;
    }

    public virtual IQueryable<TEntity> BuildQuery()
    {
        return Query;
    }

    public virtual TBuilder SetOrderBy()
    {
        if (IsOrdered is false)
        {
            Query = Query.OrderByDescending(i => i.LastModified).ThenBy(x => x.Id);

            SetIsOrdered();
        }

        return _instance;
    }
}
