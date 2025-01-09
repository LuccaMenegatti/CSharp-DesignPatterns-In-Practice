namespace CSharpDesignPatternsInPractice.Domain.Dtos.Request;

public record UpdateFootballPlayerRequest
{
    public string? Position { get; set; }
    public int? JerseyNumber { get; set; }
    public int? GoalsScored { get; set; }
    public int? Assists { get; set; }
    public Guid? FootballTeamId { get; set; }
}
