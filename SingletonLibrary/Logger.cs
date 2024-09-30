using System;
using System.IO;

namespace SingletonLibrary
{
    public class Logger
    {
        private static Logger _instance;
        private static readonly object _lock = new object();

        private Logger() { }

        public static Logger Instance
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new Logger();
                    }
                    return _instance;
                }
            }
        }

        private string _logFilePath = "log.txt";

        public void Log(string message)
        {
            using (StreamWriter writer = new StreamWriter(_logFilePath, true))
            {
                writer.WriteLine($"{DateTime.Now}: {message}");
            }
            Console.WriteLine($"Логування: {message}");
        }
    }
}
