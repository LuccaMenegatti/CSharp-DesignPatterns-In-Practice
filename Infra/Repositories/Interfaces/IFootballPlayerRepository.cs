using CSharpDesignPatternsInPractice.Domain.Entities;

namespace CSharpDesignPatternsInPractice.Infra.Repositories.Interfaces;

public interface IFootballPlayerRepository : IBaseRepository<FootballPlayerEntity>
{
    IQueryable<FootballPlayerEntity> GetWithTeam();
}
