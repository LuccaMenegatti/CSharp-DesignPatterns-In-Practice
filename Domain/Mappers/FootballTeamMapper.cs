using AtividadeEmGrupoP2.Domain.Dtos.Request;
using AtividadeEmGrupoP2.Domain.Entities;

namespace AtividadeEmGrupoP2.Domain.Mappers;

public static class FootballTeamMapper
{
    public static FootballTeamEntity ToFootballTeamEntity(this CreateFootballTeamRequest request) =>
       new()
       {
           Name = request.Name,
           Founded = request.Founded,
           Nationality = request.Nationality,
           Stadium = request.Stadium,
           Capacity = request.Capacity,
           Coach = request.Coach,
           League = request.League,
           ChampionshipsWon = request.ChampionshipsWon,
       };

    public static FootballTeamEntity ToFootballTeamEntity(this UpdateFootballTeamRequest request) =>
        new()
        {
            Coach = request.Coach,
            ChampionshipsWon = request.ChampionshipsWon,
        };
}
