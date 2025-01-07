using AtividadeEmGrupoP2.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AtividadeEmGrupoP2.Infra.Database.Interface;

public interface IApplicationDbContext
{
    public DbSet<TEntity> Set<TEntity>() where TEntity : class;
    public DbSet<FootballPlayerEntity> FootballPlayer { get; set; }
    public DbSet<FootballTeamEntity> FootballTeam { get; set; }

    Task<int> SaveChangesAsync(CancellationToken ct);
}
