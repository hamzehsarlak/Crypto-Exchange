namespace CryptoExchange.Core.Abstraction.CQRS
{
    /// <summary>
    /// Contract to mark all queries
    /// </summary>
    public interface IQuery<out TResponse>
    {
    }
}
