using CSharpDesignPatternsInPractice.Domain.Entities;

namespace CSharpDesignPatternsInPractice.Domain.Memento.FootballTeam;

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
