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
        private static DatabaseManager _instance = null;
        private SQLiteConnection dbConnection = null;
        private string database = null;

        private static string connectionStingTemplate = "Data Source={0};Version=3;Password=\"{1}\";";

        private DatabaseManager(string databaseName) {
            this.database = databaseName;
            this.dbConnection = null;
        }

        public static DatabaseManager getInstance( string databaseName )
        {
            if (_instance == null || _instance.database != databaseName )
                _instance = new DatabaseManager( databaseName );
            return _instance;
        }

        private void createDatabase()
        {
            if (!File.Exists(this.database))
            {
                Console.WriteLine("Trying to create database....\n");
                SQLiteConnection.CreateFile(this.database);
                Console.WriteLine("created database.\n");
            }
            else
            {
                Console.WriteLine("database already exists\n");
            }
        }

        private void connectToDatabase(string password="")
        {
            if (this.dbConnection == null || this.dbConnection.State.ToString() != "Open" )
            {
                Console.WriteLine("Trying to connect to database....\n");
                this.dbConnection = new SQLiteConnection(string.Format(connectionStingTemplate, this.database, password));
                this.dbConnection.Open();
                Console.WriteLine("Connected to database....\n");
            }
            
        }

        private void createTable()
        {
            //check that connection to db exists
            if (this.dbConnection == null)
                connectToDatabase(this.database);
            Console.WriteLine("Trying to create table....\n");
            string sql = "create table IF NOT EXISTS pipeline_data (ID INTEGER PRIMARY KEY AUTOINCREMENT, survey_date DATETIIME not null," +
                                                                    "pipeline_id int not null, time BLOB not null, signal BLOB not null)";
            SQLiteCommand command = new SQLiteCommand(sql, this.dbConnection);
            command.ExecuteNonQuery();
            Console.WriteLine("Table created.\n");
            
        }

        private void CloseConnection()
        {
            if (this.dbConnection != null)
            {
                this.dbConnection.Close();
                this.dbConnection = null;
            }
        }

    }
}
