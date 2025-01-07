using AtividadeEmGrupoP2.Domain.Entities;
using AtividadeEmGrupoP2.Infra.Database.Interface;
using AtividadeEmGrupoP2.Infra.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AtividadeEmGrupoP2.Infra.Repositories;

public class FootballPlayerRepository(IApplicationDbContext dbContext) : BaseRepository<FootballPlayerEntity>(dbContext),
    IFootballPlayerRepository
{
    public IQueryable<FootballPlayerEntity> GetWithTeam()
    {
        return _dbContext.FootballPlayer
            .AsNoTracking()
            .Include(x => x.FootballTeam);
    }
}
