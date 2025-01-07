using AtividadeEmGrupoP2.Domain.Entities;
using AtividadeEmGrupoP2.Infra.Database.Interface;
using AtividadeEmGrupoP2.Infra.Database.Mappers;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace AtividadeEmGrupoP2.Infra.Database;

public class ApplicationDbContext(
    DbContextOptions<ApplicationDbContext> options,
    ILogger<ApplicationDbContext> _logger) : DbContext(options), IApplicationDbContext
{
    public const string Schema = "football_manager";

    public DbSet<FootballPlayerEntity> FootballPlayer { get; set; }
    public DbSet<FootballTeamEntity> FootballTeam { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(Schema);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
        FootballPlayerEntityMap.Apply(modelBuilder.Entity<FootballPlayerEntity>());
        FootballTeamEntityMap.Apply(modelBuilder.Entity<FootballTeamEntity>());
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        try
        {
            return await base.SaveChangesAsync(cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while trying to call SaveChangesAsync.");
            throw;
        }
    }
}
