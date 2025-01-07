using AtividadeEmGrupoP2.Domain.Builders;
using AtividadeEmGrupoP2.Domain.Dtos.Request;
using AtividadeEmGrupoP2.Domain.Entities;
using AtividadeEmGrupoP2.Domain.ValueObjects.Pagination;
using AtividadeEmGrupoP2.Infra.Extensions;
using AtividadeEmGrupoP2.Infra.Repositories.Interfaces;

namespace AtividadeEmGrupoP2.Domain.UseCases.FootballPlayers;

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
