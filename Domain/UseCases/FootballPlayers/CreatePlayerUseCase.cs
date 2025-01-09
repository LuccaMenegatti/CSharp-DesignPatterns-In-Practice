using CSharpDesignPatternsInPractice.Domain.Dtos.Request;
using CSharpDesignPatternsInPractice.Domain.Entities;
using CSharpDesignPatternsInPractice.Domain.Mappers;
using CSharpDesignPatternsInPractice.Infra.Repositories.Interfaces;

namespace CSharpDesignPatternsInPractice.Domain.UseCases.FootballPlayers;

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
