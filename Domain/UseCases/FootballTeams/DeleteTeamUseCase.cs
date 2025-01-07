using AtividadeEmGrupoP2.Domain.Command;
using AtividadeEmGrupoP2.Infra.Repositories.Interfaces;

namespace AtividadeEmGrupoP2.Domain.UseCases.FootballTeams;

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