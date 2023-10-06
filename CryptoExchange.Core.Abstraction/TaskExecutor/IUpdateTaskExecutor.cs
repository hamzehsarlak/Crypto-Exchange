using System.Threading.Tasks;

namespace CryptoExchange.Core.Abstraction.TaskExecutor
{
    public interface IUpdateTaskExecutor
    {
        Task UpdateRates();
        Task UpdateListings();
        Task Notify();
        Task Execute();
    }

    public abstract class UpdateTaskExecutor : IUpdateTaskExecutor
    {
        public abstract Task UpdateRates();
        public abstract Task UpdateListings();
        public abstract Task Notify();

        public async Task Execute()
        {
            await UpdateRates();
            await UpdateListings();
            await Notify();
        }
    }
}