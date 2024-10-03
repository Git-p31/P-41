using System;

namespace SingletonLibrary
{
    public class DocumentSaver
    {
        private static DocumentSaver _instance;
        private static readonly object _lock = new object();

        private DocumentSaver() { }

        public static DocumentSaver GetInstance()
        {
            lock (_lock)
            {
                if (_instance == null)
                {
                    _instance = new DocumentSaver();
                }
                return _instance;
            }
        }

        public void SaveDocument(string documentName, string content)
        {
            Console.WriteLine($"Збереження документа: {documentName}");
        }
    }
}
