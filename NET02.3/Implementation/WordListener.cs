using NET02._3.Abstract;
using System;
using Microsoft.Office.Interop.Word;
using System.Reflection;


namespace NET02._3.Implementation
{
    public class WordListener : Listener
    {
        private readonly string _filePath;

        public WordListener(string filePath)
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
                Microsoft.Office.Interop.Word.Application app = new Microsoft.Office.Interop.Word.Application();
                Microsoft.Office.Interop.Word.Document doc = app.Documents.Open(_filePath);
                object missing = System.Reflection.Missing.Value;
                doc.Content.Text += textBox1.Text;
                doc.Save();
                doc.Close();
            }
        }
    }
}
