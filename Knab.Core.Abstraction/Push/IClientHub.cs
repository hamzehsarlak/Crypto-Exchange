using System.Threading.Tasks;

namespace Knab.Core.Abstraction.Push
{
    public interface IClientHub
    {
        Task Push(string name, string message);
    }
}