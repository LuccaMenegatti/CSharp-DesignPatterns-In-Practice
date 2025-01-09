using CSharpDesignPatternsInPractice.Domain.ValueObjects.Pagination;

namespace CSharpDesignPatternsInPractice.Domain.Dtos.Request;

public record GetPlayersRequest : PaginatedRequestBase
{
    public string Name { get; set; } = string.Empty;
    public int Age { get; set; } = 0;
    public string Nationality { get; set; } = string.Empty;
    public string Position { get; set; } = string.Empty;
    public decimal Height { get; set; } = 0;
    public decimal Weight { get; set; } = 0;
    public string Footed { get; set; } = string.Empty;
    public string FootballTeamName { get; set; } = string.Empty;
}
