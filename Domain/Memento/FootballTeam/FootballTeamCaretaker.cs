using AtividadeEmGrupoP2.Domain.Entities;

namespace AtividadeEmGrupoP2.Domain.Memento.FootballTeam;

public class FootballTeamCaretaker
{
    private readonly Stack<FootballTeamMemento> _history = new();

    public void SaveState(FootballTeamEntity team)
    {
        var memento = new FootballTeamMemento((FootballTeamEntity)team.Clone());
        _history.Push(memento);
    }

    public FootballTeamEntity RestoreState()
    {
        return _history.Pop().State;
    }
}
