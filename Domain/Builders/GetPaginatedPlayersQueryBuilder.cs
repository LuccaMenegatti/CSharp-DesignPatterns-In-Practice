using CSharpDesignPatternsInPractice.Domain.Builders;
using CSharpDesignPatternsInPractice.Domain.Dtos.Request;
using CSharpDesignPatternsInPractice.Domain.Entities;
using CSharpDesignPatternsInPractice.Infra.Repositories.Interfaces;

namespace CSharpDesignPatternsInPractice.Domain.Builders;

public sealed class GetPaginatedPlayersQueryBuilder :
    QueryBuilderBase<GetPaginatedPlayersQueryBuilder, FootballPlayerEntity, GetPlayersRequest>
{
    public static GetPaginatedPlayersQueryBuilder CreateBuilder(IFootballPlayerRepository footballPlayerRepository)
    {
        _instance = new()
        {
            Query = footballPlayerRepository.GetWithTeam()
        };

        return _instance;
    }

    public GetPaginatedPlayersQueryBuilder SetRequest(GetPlayersRequest request)
    {
        _instance.Request = request;

        return this;
    }

    public GetPaginatedPlayersQueryBuilder FilterByName()
    {
        if (string.IsNullOrEmpty(Request.Name) is false)
        {
            Query = Query.Where(i => i.Name.Contains(Request.Name));
        }

        return this;
    }

    public GetPaginatedPlayersQueryBuilder FilterByAge()
    {
        if (Request.Age > 0)
        {
            Query = Query.Where(i => i.Age == Request.Age);
        }

        return this;
    }

    public GetPaginatedPlayersQueryBuilder FilterByNationality()
    {
        if (string.IsNullOrEmpty(Request.Nationality) is false)
        {
            Query = Query.Where(i => i.Nationality.Contains(Request.Nationality));
        }

        return this;
    }

    public GetPaginatedPlayersQueryBuilder FilterByPosition()
    {
        if (string.IsNullOrEmpty(Request.Position) is false)
        {
            Query = Query.Where(i => i.Position.Contains(Request.Position));
        }

        return this;
    }

    public GetPaginatedPlayersQueryBuilder FilterByHeight()
    {
        if (Request.Height > 0)
        {
            Query = Query.Where(i => i.Height == Request.Height);
        }

        return this;
    }

    public GetPaginatedPlayersQueryBuilder FilterByWeight()
    {
        if (Request.Weight > 0)
        {
            Query = Query.Where(i => i.Weight == Request.Weight);
        }

        return this;
    }

    public GetPaginatedPlayersQueryBuilder FilterByFooted()
    {
        if (string.IsNullOrEmpty(Request.Footed) is false)
        {
            Query = Query.Where(i => i.Footed.Contains(Request.Footed));
        }

        return this;
    }

    public GetPaginatedPlayersQueryBuilder FilterByTeamName()
    {
        if (string.IsNullOrEmpty(Request.FootballTeamName) is false)
        {
            Query = Query.Where(i => i.FootballTeam!.Name.Contains(Request.FootballTeamName));
        }

        return this;
    }

    public override GetPaginatedPlayersQueryBuilder SetOrderBy()
    {
        if (IsOrdered is false)
            Query = Query.OrderByDescending(i => i.LastModified).ThenBy(x => x.Id);

        return this;
    }
}
