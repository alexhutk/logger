using NET02._3.Infrastructure;

namespace NET02._3.Interfaces
{
    public interface ILogEntity
    {
        void WriteLog(LogType logType, string message, object paramObject = null);
        void Track(object trackingObject);
    }
}
