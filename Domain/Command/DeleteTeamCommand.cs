using CSharpDesignPatternsInPractice.Infra.Repositories.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace CSharpDesignPatternsInPractice.Domain.Command;

public class DeleteTeamCommand(Guid teamId, IFootballTeamRepository footballTeamRepository)
{
    public Guid TeamId { get; } = teamId;
    private readonly IFootballTeamRepository _footballTeamRepository = footballTeamRepository;

    public async Task ExecuteAsync(CancellationToken ct)
    {
        var entity = await _footballTeamRepository.FindByIdAsync(TeamId, ct);

        if (entity.FootballPlayers != null)
            throw new ValidationException("O Time não pode ser deletado pois tem jogadores associados.");

        await _footballTeamRepository.DeleteAsync(TeamId, ct);
    }
}

