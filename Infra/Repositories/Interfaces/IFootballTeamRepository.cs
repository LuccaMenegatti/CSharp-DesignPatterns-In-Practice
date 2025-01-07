using AtividadeEmGrupoP2.Domain.Entities;

namespace AtividadeEmGrupoP2.Infra.Repositories.Interfaces;

public interface IFootballTeamRepository : IBaseRepository<FootballTeamEntity>
{
    IQueryable<FootballTeamEntity> GetAll();
}
