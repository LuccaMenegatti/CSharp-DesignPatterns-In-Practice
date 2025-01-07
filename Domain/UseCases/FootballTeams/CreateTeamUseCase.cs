using AtividadeEmGrupoP2.Domain.Dtos.Request;
using AtividadeEmGrupoP2.Domain.Entities;
using AtividadeEmGrupoP2.Domain.Mappers;
using AtividadeEmGrupoP2.Infra.Repositories.Interfaces;

namespace AtividadeEmGrupoP2.Domain.UseCases.FootballTeams;

public class CreateTeamUseCase(IFootballTeamRepository _footballTeamRepository) : ICreateTeamUseCase
{
    public async Task<FootballTeamEntity> CreateTeamAsync(CreateFootballTeamRequest request, CancellationToken ct)
    {
        var entity = request.ToFootballTeamEntity();
        return await _footballTeamRepository.CreateAsync(entity, ct);
    }
}

public interface ICreateTeamUseCase
{
    Task<FootballTeamEntity> CreateTeamAsync(CreateFootballTeamRequest request, CancellationToken ct);
}
