using CSharpDesignPatternsInPractice.Domain.Entities;
using CSharpDesignPatternsInPractice.Infra.Database.Interface;
using CSharpDesignPatternsInPractice.Infra.Repositories.Interfaces;
using CSharpDesignPatternsInPractice.Infra.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CSharpDesignPatternsInPractice.Infra.Repositories;

public class FootballTeamRepository(IApplicationDbContext dbContext) : BaseRepository<FootballTeamEntity>(dbContext),
    IFootballTeamRepository
{
    public IQueryable<FootballTeamEntity> GetAll()
    {
        return _dbContext.FootballTeam
            .AsNoTracking();
    }
}
