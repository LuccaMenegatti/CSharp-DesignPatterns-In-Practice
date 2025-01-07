using AtividadeEmGrupoP2.Domain.Entities;

namespace AtividadeEmGrupoP2.Infra.Repositories.Interfaces;

public interface IFootballPlayerRepository : IBaseRepository<FootballPlayerEntity>
{
    IQueryable<FootballPlayerEntity> GetWithTeam();
}
