using System;
using System.IO;
using System.Threading;
using Microsoft.Data.Sqlite;

namespace WindowsService1
{
    class Logger
    {
        FileSystemWatcher watcher;
        object obj = new object();
        bool enabled = true;
        public Logger()
        {
            watcher = new FileSystemWatcher("F:\\Temp");
            watcher.Created += Watcher_Created;
            watcher.Filter = "*.xml";
        }

        public void Start()
        {
            watcher.EnableRaisingEvents = true;
            while (enabled)
            {
                Thread.Sleep(1000);
            }
        }

        public void Stop()
        {
            watcher.EnableRaisingEvents = false;
            enabled = false;
        }

        private void Watcher_Created(object sender, FileSystemEventArgs e)
        {
            string fileEvent = "создан";
            string filePath = e.FullPath;
            RecordEntry(fileEvent, filePath);
        }

        private void RecordEntry(string fileEvent, string filePath)
        {
            lock (obj)
            {
                using (StreamWriter writer = new StreamWriter("F:\\Temp\\templog.txt", true))
                {
                    writer.WriteLine(String.Format("{0} файл {1} был {2}",
                        DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"), filePath, fileEvent));
                    Request request = new XmlParser(filePath).ParseRequest();
                    writer.WriteLine("{0} Получен запрос от {1} с id {2} ", request.RqTime, request.Type, request.Id );
                    writer.WriteLine("{0} Попытка записи в БД", DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"));
                    try
                    {
                        new DbConnection().AddRequest(request);
                        writer.WriteLine("{0} Успешное добавление в БД", DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"));
                    }
                    catch (SqliteException ex)
                    {
                        writer.WriteLine("{0} Ошибка {1} добавления в БД: {2}", DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"), ex.SqliteExtendedErrorCode, ex.Message);
                    }
                    writer.Flush();

                }
            }
        }


    }
}
