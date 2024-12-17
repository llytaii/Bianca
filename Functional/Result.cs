namespace Bianca;

public record Result<T> : Result<T, string> where T: notnull;

public record Result<V, E> 
    where V: notnull
    where E: notnull
{
    // Variants
    private record ResultOk(V value) : Result<V, E>;
    private record ResultError(E error) : Result<V, E>;

    // Factory Methods
    public static Result<V, E> Ok(V Value)
        => new ResultOk(Value);
    public static Result<V, E> Fail(E Error)
        => new ResultError(Error);

    // Operations
    public bool IsOk => this is ResultOk;
    public bool IsError => this is ResultError;

    public V Value => this switch
    {
        ResultOk r => r.value,
        _ => throw new InvalidOperationException($"trying to access VALUE of {this.GetType()}")
    };
    public E Error => this switch
    {
        ResultError r => r.error,
        _ => throw new InvalidOperationException($"trying to access ERROR of {this.GetType()}")
    };
}