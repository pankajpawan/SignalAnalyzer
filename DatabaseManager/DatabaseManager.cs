using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Data.SQLite;

namespace DatabaseManager
{
    public class DatabaseManager
    {
        SQLiteConnection m_dbConnection;

        private void createDatabase(string databasename, string connectionString)
        {
            if (File.Exists("GraphViewer.sqlite") == false)
            {
                Console.WriteLine("Trying to create database....\n");
                SQLiteConnection.CreateFile("GraphViewer.sqlite");
                Console.WriteLine("created database.\n");
            }
            else
            {
                Console.WriteLine("database already exists\n");
            }
            connectToDatabase();
            createTable();
            CloseConnection();
        }

        private void connectToDatabase()
        {
            Console.WriteLine("Trying to connect to database....\n");
            m_dbConnection = new SQLiteConnection("Data Source=GraphViewer.sqlite;Version=3;");
            m_dbConnection.Open();
            Console.WriteLine("Connected to database....\n");
        }

        private void createTable()
        {
            Console.WriteLine("Trying to create table....\n");
            string sql = "create table IF NOT EXISTS pipeline_data (ID INTEGER PRIMARY KEY AUTOINCREMENT, survey_date DATETIIME not null," +
                                                                    "pipeline_id int not null, time BLOB not null, signal BLOB not null)";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
            Console.WriteLine("Table created.\n");
            Console.WriteLine("Trying to close connection....\n");
            CloseConnection();
            Console.WriteLine("Connection closed.\n");
        }

        private void CloseConnection()
        {
            if (m_dbConnection != null)
            {
                m_dbConnection.Close();
                m_dbConnection = null;
            }
        }

        public byte[] getByteArray(Double[] data)
        {
            object blob = data;
            if (blob == null) return null;
            byte[] arData = (byte[])blob;
            return arData;
        }
    }
}
