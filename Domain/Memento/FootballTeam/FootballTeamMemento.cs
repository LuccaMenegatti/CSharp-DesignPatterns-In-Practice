using CSharpDesignPatternsInPractice.Domain.Entities;

namespace CSharpDesignPatternsInPractice.Domain.Memento.FootballTeam;

public class FootballTeamMemento(FootballTeamEntity state)
{
    public FootballTeamEntity State { get; } = state;
}
