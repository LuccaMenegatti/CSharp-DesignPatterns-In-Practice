using CSharpDesignPatternsInPractice.Domain.Entities;
using CSharpDesignPatternsInPractice.Infra.Database.Interface;
using CSharpDesignPatternsInPractice.Infra.Repositories.Interfaces;
using CSharpDesignPatternsInPractice.Infra.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CSharpDesignPatternsInPractice.Infra.Repositories;

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
