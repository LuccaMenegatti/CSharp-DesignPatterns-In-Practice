using CSharpDesignPatternsInPractice.Domain.Entities;
using CSharpDesignPatternsInPractice.Infra.Repositories.Interfaces;

namespace CSharpDesignPatternsInPractice.Domain.UseCases.FootballPlayers;

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
