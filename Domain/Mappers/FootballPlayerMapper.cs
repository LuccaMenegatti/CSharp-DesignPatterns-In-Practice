using CSharpDesignPatternsInPractice.Domain.Dtos.Request;
using CSharpDesignPatternsInPractice.Domain.Entities;

namespace CSharpDesignPatternsInPractice.Domain.Mappers;

public static class FootballPlayerMapper
{
    public static FootballPlayerEntity ToFootballPlayerEntity(this CreateFootballPlayerRequest request) =>
       new()
       {
           Name = request.Name,
           Age = request.Age,
           Nationality = request.Nationality,
           Position = request.Position,
           JerseyNumber = request.JerseyNumber,
           Height = request.Height,
           Weight = request.Weight,
           DateOfBirth = request.DateOfBirth,
           Footed = request.Footed,
           GoalsScored = request.GoalsScored,
           Assists = request.Assists,
           Created = DateTime.UtcNow.ToUniversalTime(),
           CreatedBy = "System",
           LastModified = DateTime.UtcNow.ToUniversalTime(),
           LastModifiedBy = "System"
       };
}
