
using System.Threading.Tasks;

namespace Knab.Core.Abstraction.TaskScheduler
{
    public interface ITaskScheduler
    {
        void ScheduleUpdateRates();
        void ScheduleUpdateListings();
    }

    public abstract class TaskSchedulerBuilder 
    {
        public abstract Task UpdateRates();
        public abstract Task UpdateListings();
        public abstract void Schedule();
    }
    
    public class TaskSchedulerDirector
    {
        public void Build(TaskSchedulerBuilder builder)
        {
            builder.UpdateRates();
            builder.UpdateListings();
            builder.Schedule();
        }
    }
    
}