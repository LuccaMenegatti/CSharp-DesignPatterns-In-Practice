using AtividadeEmGrupoP2.Infra.Repositories.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace AtividadeEmGrupoP2.Domain.Command;

public class DeletePlayerCommand(Guid playerId, IFootballPlayerRepository footballPlayerRepository)
{
    public Guid PlayerId { get; } = playerId;
    private readonly IFootballPlayerRepository _footballPlayerRepository = footballPlayerRepository;

    public async Task ExecuteAsync(CancellationToken ct)
    {
        var entity = await _footballPlayerRepository.FindByIdAsync(PlayerId, ct);

        if (entity.FootballTeamId != null)
            throw new ValidationException("O jogador não pode ser deletado pois está associado a um time");

        await _footballPlayerRepository.DeleteAsync(PlayerId, ct);
    }
}
