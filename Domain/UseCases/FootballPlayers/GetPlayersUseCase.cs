using CSharpDesignPatternsInPractice.Domain.Dtos.Request;
using CSharpDesignPatternsInPractice.Domain.Entities;
using CSharpDesignPatternsInPractice.Domain.ValueObjects.Pagination;
using CSharpDesignPatternsInPractice.Infra.Extensions;
using CSharpDesignPatternsInPractice.Infra.Repositories.Interfaces;
using CSharpDesignPatternsInPractice.Domain.Builders;

namespace CSharpDesignPatternsInPractice.Domain.UseCases.FootballPlayers;

public class GetPlayersUseCase(IFootballPlayerRepository _footballPlayerRepository) : IGetPlayersUseCase
{
    public async Task<PaginatedResult<FootballPlayerEntity>> GetAsync(GetPlayersRequest filter, CancellationToken ct)
    {
        var response = await GetPlayersByFilterAsync(filter, ct);

        return response;
    }

    private async Task<PaginatedResult<FootballPlayerEntity>> GetPlayersByFilterAsync(GetPlayersRequest filter, CancellationToken ct)
    {
        var query = GetPaginatedPlayersQueryBuilder
            .CreateBuilder(_footballPlayerRepository)
            .SetRequest(filter)
            .FilterByName()
            .FilterByAge()
            .FilterByNationality()
            .FilterByPosition()
            .FilterByHeight()
            .FilterByWeight()
            .FilterByFooted()
            .FilterByTeamName()
            .SetOrderBy()
            .BuildQuery();

        return await query.GetPaginatedAsync(filter.Page, filter.PageSize, ct);
    }
}

public interface IGetPlayersUseCase
{
    Task<PaginatedResult<FootballPlayerEntity>> GetAsync(GetPlayersRequest filter, CancellationToken ct);
}
