using CSharpDesignPatternsInPractice.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CSharpDesignPatternsInPractice.Infra.Database.Mappers;

public static class FootballPlayerEntityMap
{
    public static void Apply(EntityTypeBuilder<FootballPlayerEntity> entityBuilder)
    {
        entityBuilder.HasKey(x => x.Id);
        entityBuilder.ToTable("football_player");
        entityBuilder.Property(x => x.Id).HasColumnName("id");
        entityBuilder.Property(x => x.Name).HasColumnName("name");
        entityBuilder.Property(x => x.Age).HasColumnName("age");
        entityBuilder.Property(x => x.Nationality).HasColumnName("nationality");
        entityBuilder.Property(x => x.Position).HasColumnName("position");
        entityBuilder.Property(x => x.JerseyNumber).HasColumnName("jersey_number");
        entityBuilder.Property(x => x.Height).HasColumnName("height");
        entityBuilder.Property(x => x.Weight).HasColumnName("weight");
        entityBuilder.Property(x => x.DateOfBirth).HasColumnName("date_of_birth");
        entityBuilder.Property(x => x.Footed).HasColumnName("footed");
        entityBuilder.Property(x => x.GoalsScored).HasColumnName("goals_scored");
        entityBuilder.Property(x => x.Assists).HasColumnName("assists");
        entityBuilder.Property(x => x.FootballTeamId).HasColumnName("football_team_id");

        entityBuilder.Property(prop => prop.Created).HasColumnName("created");
        entityBuilder.Property(prop => prop.CreatedBy).HasColumnName("created_by").HasDefaultValue(string.Empty);
        entityBuilder.Property(prop => prop.LastModified).HasColumnName("last_modified");
        entityBuilder.Property(prop => prop.LastModifiedBy).HasColumnName("last_modified_by").HasDefaultValue(string.Empty);
    }
}
