using AtividadeEmGrupoP2.Domain.Entities.Common;

namespace AtividadeEmGrupoP2.Domain.Entities;

public class FootballPlayerEntity : AuditableEntityBase<Guid>
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
    public Guid? FootballTeamId { get; set; }
    public FootballTeamEntity? FootballTeam { get; set; }

    public FootballPlayerEntity Clone()
    {
        return (FootballPlayerEntity)MemberwiseClone();
    }
}


