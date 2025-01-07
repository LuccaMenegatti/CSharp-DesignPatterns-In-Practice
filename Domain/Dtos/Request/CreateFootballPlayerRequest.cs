namespace AtividadeEmGrupoP2.Domain.Dtos.Request;

public record CreateFootballPlayerRequest
{
    public string Name { get; set; } = string.Empty;
    public int Age { get; set; }
    public string Nationality { get; set; } = string.Empty;
    public string Position { get; set; } = string.Empty;
    public int JerseyNumber { get; set; }
    public decimal Height { get; set; }
    public decimal Weight { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Footed { get; set; } = string.Empty;
    public int GoalsScored { get; set; }
    public int Assists { get; set; }
}
