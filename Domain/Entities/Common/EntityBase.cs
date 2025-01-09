namespace CSharpDesignPatternsInPractice.Domain.Entities.Common;

public class EntityBase<T>
{
    public T? Id { get; set; }
}
