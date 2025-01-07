using AtividadeEmGrupoP2.Domain.Builders;
using AtividadeEmGrupoP2.Domain.Dtos.Request;
using AtividadeEmGrupoP2.Domain.Entities;
using AtividadeEmGrupoP2.Domain.ValueObjects.Pagination;
using AtividadeEmGrupoP2.Infra.Extensions;
using AtividadeEmGrupoP2.Infra.Repositories.Interfaces;

namespace AtividadeEmGrupoP2.Domain.UseCases.FootballTeams;

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
