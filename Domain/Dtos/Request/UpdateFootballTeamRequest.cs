﻿namespace CSharpDesignPatternsInPractice.Domain.Dtos.Request;

public record UpdateFootballTeamRequest
{
    public string Coach { get; set; } = string.Empty;
    public int ChampionshipsWon { get; set; }
}
