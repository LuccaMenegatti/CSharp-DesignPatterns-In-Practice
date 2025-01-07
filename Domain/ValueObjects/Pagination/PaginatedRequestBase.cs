namespace AtividadeEmGrupoP2.Domain.ValueObjects.Pagination;

public record PaginatedRequestBase
{
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}
