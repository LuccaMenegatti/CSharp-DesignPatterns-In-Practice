using AtividadeEmGrupoP2.Domain.ValueObjects.Pagination;

namespace AtividadeEmGrupoP2.Domain.Dtos.Request;

public record GetTeamsRequest : PaginatedRequestBase
{
    public string Name { get; set; } = string.Empty;
    public DateTime? Founded { get; set; }
    public string Nationality { get; set; } = string.Empty;
    public string Stadium { get; set; } = string.Empty;
    public string Coach { get; set; } = string.Empty;
    public string League { get; set; } = string.Empty;
}
