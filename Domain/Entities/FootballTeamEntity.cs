using AtividadeEmGrupoP2.Domain.Entities.Common;

namespace AtividadeEmGrupoP2.Domain.Entities;

public class FootballTeamEntity : AuditableEntityBase<Guid>
{
    public string Name { get; set; } = string.Empty;
    public DateTime Founded { get; set; }
    public string Nationality { get; set; } = string.Empty;
    public string Stadium { get; set; } = string.Empty;
    public int Capacity { get; set; }
    public string Coach { get; set; } = string.Empty;
    public string League { get; set; } = string.Empty;
    public int ChampionshipsWon { get; set; }
    public List<FootballPlayerEntity>? FootballPlayers { get; set; }

    public FootballTeamEntity Clone()
    {
        return (FootballTeamEntity)MemberwiseClone();
    }
}
