using NET02._3.Abstract;
using System;
using System.IO;

namespace NET02._3.Implementation
{
    public class TextListener : Listener
    {
        private readonly string _filePath;

        public TextListener(string filePath)
        {
            _filePath = filePath;
        }

        public override void Track(object trackingObject)
        {
            throw new NotImplementedException();
        }

        public override void Log(string outputMessage)
        {
            lock (lockObj)
            {
                using (StreamWriter streamWriter = new StreamWriter(_filePath))
                {
                    streamWriter.WriteLine(outputMessage);
                    streamWriter.Close();
                }
            }
        }
    }
}
