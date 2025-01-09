using CSharpDesignPatternsInPractice.Domain.Entities;

namespace CSharpDesignPatternsInPractice.Domain.Memento.FootballPlayer;

public class FootballPlayerCaretaker
{
    private readonly Stack<FootballPlayerMemento> _history = new();

    public void SaveState(FootballPlayerEntity player)
    {
        var memento = new FootballPlayerMemento((FootballPlayerEntity)player.Clone());
        _history.Push(memento);
    }

    public FootballPlayerEntity RestoreState()
    {
        return _history.Pop().State;
    }
}
