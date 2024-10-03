using System;
using SingletonLibrary;

namespace SingletonApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Використання DbManager
            DbManager.GetInstance().ConnectToDatabase();
            DbManager.GetInstance().Query("SELECT * FROM Users");

            // Використання DocumentSaver
            DocumentSaver.GetInstance().SaveDocument("MyDoc.txt", "Це приклад контенту документа");

            // Використання Logger
            Logger.GetInstance().Log("Запуск програми");
            Logger.GetInstance().Log("Підключення до бази даних завершено");
        }
    }
}
