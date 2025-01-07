using AtividadeEmGrupoP2.Domain.Entities;

namespace AtividadeEmGrupoP2.Domain.Memento.FootballPlayer;

public class FootballPlayerMemento(FootballPlayerEntity state)
{
    public FootballPlayerEntity State { get; } = state;
}
