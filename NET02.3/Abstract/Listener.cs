using NET02._3.Infrastructure;
using NET02._3.Interfaces;
using System;

namespace NET02._3.Abstract
{
    public abstract class Listener : IListener
    {
        protected readonly object lockObj = new object();

        public abstract void Track(object trackingObject);
        public abstract void Log(string outpuMessage);

        public void WriteLog(LogType logType, string message, object paramObject = null)
        {
            string outputMessage = FormOutputString(logType, message, paramObject);

            Log(outputMessage);
        }

        protected string FormOutputString(LogType logType, string message, object paramObject = null)
        {
            string output = "";

            switch (logType)
            {
                case LogType.Debug:
                    {
                        output = $"{DateTime.Now} | Debug | {message} | {paramObject?.ToString()}";
                        break;
                    }
                case LogType.Info:
                    {
                        output = $"{DateTime.Now} | Info | {message} | {paramObject?.ToString()}";
                        break;
                    }
                case LogType.Warn:
                    {
                        output = $"{DateTime.Now} | Warn | {message} | {paramObject?.ToString()}";
                        break;
                    }
                case LogType.Error:
                    {
                        output = $"{DateTime.Now} | Error | {message} | {((Exception)paramObject)?.Message} | {((Exception)paramObject)?.StackTrace}";
                        break;
                    }
                default:
                    {
                        output = $"{DateTime.Now} | Debug | {message} | {paramObject?.ToString()}";
                        break;
                    }
            }

            return output;
        }
    }
}
