using CSharpDesignPatternsInPractice.Domain.Entities;

namespace CSharpDesignPatternsInPractice.Infra.Repositories.Interfaces;

public interface IFootballTeamRepository : IBaseRepository<FootballTeamEntity>
{
    IQueryable<FootballTeamEntity> GetAll();
}
