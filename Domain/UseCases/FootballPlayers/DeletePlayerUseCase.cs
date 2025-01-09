using CSharpDesignPatternsInPractice.Domain.Command;
using CSharpDesignPatternsInPractice.Infra.Repositories.Interfaces;

namespace CSharpDesignPatternsInPractice.Domain.UseCases.FootballPlayers;

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
