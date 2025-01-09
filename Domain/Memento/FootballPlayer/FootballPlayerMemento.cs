using CSharpDesignPatternsInPractice.Domain.Entities;

namespace CSharpDesignPatternsInPractice.Domain.Memento.FootballPlayer;

public class FootballPlayerMemento(FootballPlayerEntity state)
{
    public FootballPlayerEntity State { get; } = state;
}
