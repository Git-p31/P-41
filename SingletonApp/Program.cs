using System;
using SingletonLibrary;

namespace SingletonApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Використання DbManager
            DbManager.Instance.ConnectToDatabase();
            DbManager.Instance.Query("SELECT * FROM Users");

            // Використання DocumentSaver
            DocumentSaver.Instance.SaveDocument("MyDoc.txt", "Це приклад контенту документа");

            // Використання Logger
            Logger.Instance.Log("Запуск програми");
            Logger.Instance.Log("Підключення до бази даних завершено");
        }
    }
}
