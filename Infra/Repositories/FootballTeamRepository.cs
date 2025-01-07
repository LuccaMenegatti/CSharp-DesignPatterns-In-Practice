using AtividadeEmGrupoP2.Domain.Entities;
using AtividadeEmGrupoP2.Infra.Database.Interface;
using AtividadeEmGrupoP2.Infra.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AtividadeEmGrupoP2.Infra.Repositories;

public class FootballTeamRepository(IApplicationDbContext dbContext) : BaseRepository<FootballTeamEntity>(dbContext),
    IFootballTeamRepository
{
    public IQueryable<FootballTeamEntity> GetAll()
    {
        return _dbContext.FootballTeam
            .AsNoTracking();
    }
}
