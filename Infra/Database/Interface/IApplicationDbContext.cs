using CSharpDesignPatternsInPractice.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CSharpDesignPatternsInPractice.Infra.Database.Interface;

public interface IApplicationDbContext
{
    public DbSet<TEntity> Set<TEntity>() where TEntity : class;
    public DbSet<FootballPlayerEntity> FootballPlayer { get; set; }
    public DbSet<FootballTeamEntity> FootballTeam { get; set; }

    Task<int> SaveChangesAsync(CancellationToken ct);
}
