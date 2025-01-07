﻿using AtividadeEmGrupoP2.Domain.CustomExceptions;
using AtividadeEmGrupoP2.Domain.Entities.Common;
using AtividadeEmGrupoP2.Infra.Database.Interface;
using AtividadeEmGrupoP2.Infra.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AtividadeEmGrupoP2.Infra.Repositories;

public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : AuditableEntityBase<Guid>
{
    protected readonly IApplicationDbContext _dbContext;

    protected BaseRepository(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<TEntity> CreateAsync(TEntity entity, CancellationToken ct)
    {
        await _dbContext.Set<TEntity>().AddAsync(entity, ct);
        await _dbContext.SaveChangesAsync(ct);

        return entity;
    }

    public async Task<TEntity> UpdateAsync(TEntity entity, CancellationToken ct)
    {
        _dbContext.Set<TEntity>().Update(entity);
        await _dbContext.SaveChangesAsync(ct);

        return entity;
    }

    public async Task<TEntity> FindByIdAsync(Guid id, CancellationToken ct)
    {
        return await _dbContext
            .Set<TEntity>()
            .FirstOrDefaultAsync(x => x.Id == id, ct) ??
                throw new ResourceNotFoundException($"Entidade não encontrada com o id: {id}");
    }

    public async Task DeleteAsync(Guid id, CancellationToken ct)
    {
        var entity = await FindByIdAsync(id, ct);

        _dbContext.Set<TEntity>().Remove(entity);
        await _dbContext.SaveChangesAsync(ct);
    }
}