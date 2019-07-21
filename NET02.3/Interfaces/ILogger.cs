using NET02._3.Abstract;

namespace NET02._3.Interfaces
{
    public interface ILogger : ILogEntity
    {
        void AddListener(Listener listener);
        void RemoveListener(Listener listener);
    }
}
