using AtividadeEmGrupoP2.Domain.Entities;

namespace AtividadeEmGrupoP2.Domain.Memento.FootballTeam;

public class FootballTeamMemento(FootballTeamEntity state)
{
    public FootballTeamEntity State { get; } = state;
}
