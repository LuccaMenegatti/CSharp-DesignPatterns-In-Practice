using AtividadeEmGrupoP2.Domain.Entities;
using AtividadeEmGrupoP2.Infra.Repositories.Interfaces;

namespace AtividadeEmGrupoP2.Domain.UseCases.FootballTeams;

public class GetTeamByIdUseCase(IFootballTeamRepository _footballTeamRepository) : IGetTeamByIdUseCase
{
    public async Task<FootballTeamEntity> GetTeamByIdAsync(Guid id, CancellationToken ct)
    {
        return await _footballTeamRepository.FindByIdAsync(id, ct);
    }
}

public interface IGetTeamByIdUseCase
{
    Task<FootballTeamEntity> GetTeamByIdAsync(Guid id, CancellationToken ct);
}
