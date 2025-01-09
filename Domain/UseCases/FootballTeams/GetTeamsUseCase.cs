using CSharpDesignPatternsInPractice.Domain.Builders;
using CSharpDesignPatternsInPractice.Domain.Dtos.Request;
using CSharpDesignPatternsInPractice.Domain.Entities;
using CSharpDesignPatternsInPractice.Domain.ValueObjects.Pagination;
using CSharpDesignPatternsInPractice.Infra.Extensions;
using CSharpDesignPatternsInPractice.Infra.Repositories.Interfaces;

namespace CSharpDesignPatternsInPractice.Domain.UseCases.FootballTeams;

public class GetTeamsUseCase(IFootballTeamRepository _footballTeamRepository) : IGetTeamsUseCase
{
    public async Task<PaginatedResult<FootballTeamEntity>> GetAsync(GetTeamsRequest filter, CancellationToken ct)
    {
        var response = await GetTeamsByFilterAsync(filter, ct);
        return response;
    }

    private async Task<PaginatedResult<FootballTeamEntity>> GetTeamsByFilterAsync(GetTeamsRequest filter, CancellationToken ct)
    {
        var query = GetPaginatedTeamsQueryBuilder
            .CreateBuilder(_footballTeamRepository)
            .SetRequest(filter)
            .FilterByName()
            .FilterByFounded()
            .FilterByNationality()
            .FilterByStadium()
            .FilterByCoach()
            .FilterByLeague()
            .SetOrderBy()
            .BuildQuery();

        return await query.GetPaginatedAsync(filter.Page, filter.PageSize, ct);
    }
}

public interface IGetTeamsUseCase
{
    Task<PaginatedResult<FootballTeamEntity>> GetAsync(GetTeamsRequest filter, CancellationToken ct);
}
