using CSharpDesignPatternsInPractice.Domain.Dtos.Request;
using CSharpDesignPatternsInPractice.Domain.Entities;
using CSharpDesignPatternsInPractice.Domain.Memento.FootballTeam;
using CSharpDesignPatternsInPractice.Infra.Repositories.Interfaces;

namespace CSharpDesignPatternsInPractice.Domain.UseCases.FootballTeams;

public class UpdateTeamUseCase(IFootballTeamRepository footballTeamRepository) : IUpdateTeamUseCase
{
    private readonly IFootballTeamRepository _footballTeamRepository = footballTeamRepository;
    private readonly FootballTeamCaretaker _caretaker = new FootballTeamCaretaker();

    public async Task<FootballTeamEntity> UpdateAsync(Guid id, UpdateFootballTeamRequest request, CancellationToken ct)
    {
        var entity = await _footballTeamRepository.FindByIdAsync(id, ct);

        _caretaker.SaveState(entity);

        entity.Coach = request.Coach ?? entity.Coach;
        entity.ChampionshipsWon = request.ChampionshipsWon;

        try
        {
            return await _footballTeamRepository.UpdateAsync(entity, ct);
        }
        catch (Exception ex)
        {
            var previousState = _caretaker.RestoreState();
            await _footballTeamRepository.UpdateAsync(previousState, ct);
            throw new Exception("Update failed, reverted to previous state.", ex);
        }
    }
}

public interface IUpdateTeamUseCase
{
    Task<FootballTeamEntity> UpdateAsync(Guid id, UpdateFootballTeamRequest request, CancellationToken ct);
}
