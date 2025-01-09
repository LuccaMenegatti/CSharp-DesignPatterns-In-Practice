using CSharpDesignPatternsInPractice.Domain.Command;
using CSharpDesignPatternsInPractice.Infra.Repositories.Interfaces;

namespace CSharpDesignPatternsInPractice.Domain.UseCases.FootballTeams;

public class DeleteTeamUseCase(IFootballTeamRepository footballTeamRepository) : IDeleteTeamUseCase
{
    private readonly IFootballTeamRepository _footballTeamRepository = footballTeamRepository;

    public async Task DeleteAsync(Guid id, CancellationToken ct)
    {
        var command = new DeleteTeamCommand(id, _footballTeamRepository);
        await command.ExecuteAsync(ct);
    }
}

public interface IDeleteTeamUseCase
{
    Task DeleteAsync(Guid id, CancellationToken ct);
}