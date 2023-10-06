using System.Threading.Tasks;

namespace CryptoExchange.Core.Abstraction.Push
{
    public interface IClientHub
    {
        Task Push(string name, string message);
    }
}