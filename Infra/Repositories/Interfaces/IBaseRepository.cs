namespace CSharpDesignPatternsInPractice.Infra.Repositories.Interfaces;

public interface IBaseRepository<TEntity> where TEntity : class
{
    Task<TEntity> CreateAsync(TEntity entity, CancellationToken ct);
    Task<TEntity> UpdateAsync(TEntity entity, CancellationToken ct);
    Task<TEntity> FindByIdAsync(Guid id, CancellationToken ct);
    Task DeleteAsync(Guid id, CancellationToken ct);
}
