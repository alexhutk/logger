using NET02._3.Abstract;
using NET02._3.Infrastructure;
using NET02._3.Interfaces;
using System.Collections.Generic;

namespace NET02._3.Implementation
{
    public class Logger : ILogger
    {
        private readonly LogType _loggerType;
        private readonly List<Listener> _listeners;

        public Logger(LogType loggerType)
        {
            _loggerType = loggerType;
            ConfigureLogger();
        }

        protected virtual void ConfigureLogger()
        {

        }

        public void AddListener(Listener listener)
        {
            if (listener != null)
                _listeners.Add(listener);
        }

        public void RemoveListener(Listener listener)
        {
            if (listener != null)
                _listeners.Remove(listener);
        }

        public void Track(object trackingObject)
        {
            foreach (var child in _listeners)
                child.Track(trackingObject);
        }

        public void WriteLog(LogType logType, string message, object paramObject = null)
        {
            if (logType < _loggerType)
                return;

            foreach (var child in _listeners)
                child.WriteLog(logType, message, paramObject);
        }
    }
}
