using System;

namespace SingletonLibrary
{
    public class DbManager
    {
        private static DbManager _instance;
        private static readonly object _lock = new object();

        private DbManager() { }

        public static DbManager Instance
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new DbManager();
                    }
                    return _instance;
                }
            }
        }

        public void ConnectToDatabase()
        {
            Console.WriteLine("Підключення до бази даних.");
        }

        public void Query(string sql)
        {
            Console.WriteLine($"Виконання SQL-запиту: {sql}");
        }
    }
}
