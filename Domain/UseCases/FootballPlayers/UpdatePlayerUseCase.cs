﻿using CSharpDesignPatternsInPractice.Domain.Dtos.Request;
using CSharpDesignPatternsInPractice.Domain.Entities;
using CSharpDesignPatternsInPractice.Domain.Memento.FootballPlayer;
using CSharpDesignPatternsInPractice.Infra.Repositories.Interfaces;

namespace CSharpDesignPatternsInPractice.Domain.UseCases.FootballPlayers;

public class UpdatePlayerUseCase(IFootballPlayerRepository footballPlayerRepository) : IUpdatePlayerUseCase
{
    private readonly IFootballPlayerRepository _footballPlayerRepository = footballPlayerRepository;
    private readonly FootballPlayerCaretaker _caretaker = new FootballPlayerCaretaker();

    public async Task<FootballPlayerEntity> UpdateAsync(Guid id, UpdateFootballPlayerRequest request, CancellationToken ct)
    {
        var entity = await _footballPlayerRepository.FindByIdAsync(id, ct);

        _caretaker.SaveState(entity);

        entity.Position = request.Position ?? entity.Position;
        entity.JerseyNumber = request.JerseyNumber ?? entity.JerseyNumber;
        entity.GoalsScored = request.GoalsScored ?? entity.GoalsScored;
        entity.Assists = request.Assists ?? entity.Assists;
        entity.FootballTeamId = request.FootballTeamId ?? entity.FootballTeamId;

        try
        {
            return await _footballPlayerRepository.UpdateAsync(entity, ct);
        }
        catch (Exception ex)
        {
            var previousState = _caretaker.RestoreState();
            await _footballPlayerRepository.UpdateAsync(previousState, ct);
            throw new Exception("Update failed, reverted to previous state.", ex);
        }
    }
}

public interface IUpdatePlayerUseCase
{
    Task<FootballPlayerEntity> UpdateAsync(Guid id, UpdateFootballPlayerRequest request, CancellationToken ct);
}