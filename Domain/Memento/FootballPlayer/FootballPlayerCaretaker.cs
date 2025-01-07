using AtividadeEmGrupoP2.Domain.Entities;

namespace AtividadeEmGrupoP2.Domain.Memento.FootballPlayer;

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
