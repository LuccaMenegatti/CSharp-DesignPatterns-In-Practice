using CSharpDesignPatternsInPractice.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CSharpDesignPatternsInPractice.Infra.Database.Mappers;

public static class FootballTeamEntityMap
{
    public static void Apply(EntityTypeBuilder<FootballTeamEntity> entityBuilder)
    {
        entityBuilder.HasKey(x => x.Id);
        entityBuilder.ToTable("football_team");
        entityBuilder.Property(x => x.Id).HasColumnName("id");
        entityBuilder.Property(x => x.Name).HasColumnName("name");
        entityBuilder.Property(x => x.Founded).HasColumnName("founded");
        entityBuilder.Property(x => x.Nationality).HasColumnName("nationality");
        entityBuilder.Property(x => x.Stadium).HasColumnName("stadium");
        entityBuilder.Property(x => x.Capacity).HasColumnName("capacity");
        entityBuilder.Property(x => x.Coach).HasColumnName("coach");
        entityBuilder.Property(x => x.League).HasColumnName("league");
        entityBuilder.Property(x => x.ChampionshipsWon).HasColumnName("championships_won");

        entityBuilder.Property(prop => prop.Created).HasColumnName("created");
        entityBuilder.Property(prop => prop.CreatedBy).HasColumnName("created_by").HasDefaultValue(string.Empty);
        entityBuilder.Property(prop => prop.LastModified).HasColumnName("last_modified");
        entityBuilder.Property(prop => prop.LastModifiedBy).HasColumnName("last_modified_by").HasDefaultValue(string.Empty);

        entityBuilder.HasMany(x => x.FootballPlayers)
            .WithOne(x => x.FootballTeam)
            .HasForeignKey(x => x.FootballTeamId);
    }
}
