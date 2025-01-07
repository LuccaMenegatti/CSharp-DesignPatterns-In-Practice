using AtividadeEmGrupoP2.Domain.Entities;
using AtividadeEmGrupoP2.Infra.Repositories.Interfaces;

namespace AtividadeEmGrupoP2.Domain.UseCases.FootballPlayers;

public class GetPlayerByIdUseCase(IFootballPlayerRepository _footballPlayerRepository) : IGetPlayerByIdUseCase
{
    public async Task<FootballPlayerEntity> GetPlayerByIdAsync(Guid id, CancellationToken ct)
    {
        return await _footballPlayerRepository.FindByIdAsync(id, ct);
    }
}

public interface IGetPlayerByIdUseCase
{
    Task<FootballPlayerEntity> GetPlayerByIdAsync(Guid id, CancellationToken ct);
}
