using AtividadeEmGrupoP2.Domain.Command;
using AtividadeEmGrupoP2.Infra.Repositories.Interfaces;

namespace AtividadeEmGrupoP2.Domain.UseCases.FootballPlayers;

public class DeletePlayerUseCase(IFootballPlayerRepository footballPlayerRepository) : IDeletePlayerUseCase
{
    private readonly IFootballPlayerRepository _footballPlayerRepository = footballPlayerRepository;

    public async Task DeleteAsync(Guid id, CancellationToken ct)
    {
        var command = new DeletePlayerCommand(id, _footballPlayerRepository);
        await command.ExecuteAsync(ct);
    }
}

public interface IDeletePlayerUseCase
{
    Task DeleteAsync(Guid id, CancellationToken ct);
}
