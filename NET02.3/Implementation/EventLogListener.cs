using NET02._3.Abstract;
using System;
using System.Diagnostics;

namespace NET02._3.Implementation
{
    public class EventLogListener : Listener
    {
        public override void Track(object trackingObject)
        {
            throw new NotImplementedException();
        }

        public override void Log(string outputMessage)
        {
            lock (lockObj)
            {
                EventLog m_EventLog = new EventLog("");
                m_EventLog.Source = "TrainingEventLog";
                m_EventLog.WriteEntry(outputMessage);
            }
        }
    }
}