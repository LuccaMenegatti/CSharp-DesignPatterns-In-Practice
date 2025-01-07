using AtividadeEmGrupoP2.Domain.Dtos.Request;
using AtividadeEmGrupoP2.Domain.Entities;
using AtividadeEmGrupoP2.Domain.Mappers;
using AtividadeEmGrupoP2.Infra.Repositories.Interfaces;

namespace AtividadeEmGrupoP2.Domain.UseCases.FootballPlayers;

public class CreatePlayerUseCase(IFootballPlayerRepository _footballPlayerRepository) : ICreatePlayerUseCase
{
    public async Task<FootballPlayerEntity> CreateAsync(CreateFootballPlayerRequest request, CancellationToken ct)
    {
        var entity = request.ToFootballPlayerEntity();
        return await _footballPlayerRepository.CreateAsync(entity, ct);
    }
}

public interface ICreatePlayerUseCase
{
    Task<FootballPlayerEntity> CreateAsync(CreateFootballPlayerRequest request, CancellationToken ct);
}
