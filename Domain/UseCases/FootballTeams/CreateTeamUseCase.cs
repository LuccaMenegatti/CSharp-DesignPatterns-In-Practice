using CSharpDesignPatternsInPractice.Domain.Dtos.Request;
using CSharpDesignPatternsInPractice.Domain.Entities;
using CSharpDesignPatternsInPractice.Domain.Mappers;
using CSharpDesignPatternsInPractice.Infra.Repositories.Interfaces;

namespace CSharpDesignPatternsInPractice.Domain.UseCases.FootballTeams;

public class CreateTeamUseCase(IFootballTeamRepository _footballTeamRepository) : ICreateTeamUseCase
{
    public async Task<FootballTeamEntity> CreateTeamAsync(CreateFootballTeamRequest request, CancellationToken ct)
    {
        var entity = request.ToFootballTeamEntity();
        return await _footballTeamRepository.CreateAsync(entity, ct);
    }
}

public interface ICreateTeamUseCase
{
    Task<FootballTeamEntity> CreateTeamAsync(CreateFootballTeamRequest request, CancellationToken ct);
}
