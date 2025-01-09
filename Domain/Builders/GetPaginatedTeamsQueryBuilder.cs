using CSharpDesignPatternsInPractice.Domain.Dtos.Request;
using CSharpDesignPatternsInPractice.Domain.Entities;
using CSharpDesignPatternsInPractice.Infra.Repositories.Interfaces;

namespace CSharpDesignPatternsInPractice.Domain.Builders;

public class GetPaginatedTeamsQueryBuilder :
    QueryBuilderBase<GetPaginatedTeamsQueryBuilder, FootballTeamEntity, GetTeamsRequest>
{
    public static GetPaginatedTeamsQueryBuilder CreateBuilder(IFootballTeamRepository footballTeamRepository)
    {
        _instance = new()
        {
            Query = footballTeamRepository.GetAll()
        };

        return _instance;
    }

    public GetPaginatedTeamsQueryBuilder SetRequest(GetTeamsRequest request)
    {
        _instance.Request = request;

        return this;
    }

    public GetPaginatedTeamsQueryBuilder FilterByName()
    {
        if (string.IsNullOrEmpty(Request.Name) is false)
        {
            Query = Query.Where(i => i.Name.Contains(Request.Name));
        }

        return this;
    }

    public GetPaginatedTeamsQueryBuilder FilterByFounded()
    {
        if (Request.Founded.HasValue)
        {
            var targetDate = Request.Founded.Value.ToUniversalTime();
            Query = Query.Where(i => i.Founded.Date == targetDate.Date);
        }

        return this;
    }

    public GetPaginatedTeamsQueryBuilder FilterByNationality()
    {
        if (string.IsNullOrEmpty(Request.Nationality) is false)
        {
            Query = Query.Where(i => i.Nationality.Contains(Request.Nationality));
        }

        return this;
    }

    public GetPaginatedTeamsQueryBuilder FilterByStadium()
    {
        if (string.IsNullOrEmpty(Request.Stadium) is false)
        {
            Query = Query.Where(i => i.Stadium.Contains(Request.Stadium));
        }

        return this;
    }

    public GetPaginatedTeamsQueryBuilder FilterByCoach()
    {
        if (string.IsNullOrEmpty(Request.Coach) is false)
        {
            Query = Query.Where(i => i.Coach.Contains(Request.Coach));
        }

        return this;
    }

    public GetPaginatedTeamsQueryBuilder FilterByLeague()
    {
        if (string.IsNullOrEmpty(Request.League) is false)
        {
            Query = Query.Where(i => i.League.Contains(Request.League));
        }

        return this;
    }

    public override GetPaginatedTeamsQueryBuilder SetOrderBy()
    {
        if (IsOrdered is false)
            Query = Query.OrderByDescending(i => i.LastModified).ThenBy(x => x.Id);

        return this;
    }
}

