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

        private string connectionStingTemplate = "Data Source={0};Version=3;Password=\"{1}\";";
        private string selectQuery = @"SELECT survey_date, pipeline_id, time, signal, date_ins FROM pipeline_data WHERE survey_date = @survery_date";
        //private string l_strUpdateQuery = @"UPDATE pipeline_data SET content = content || @new_content, size = size + @size WHERE id = @id AND chunk = @chunk";
        private string insertQuery = @"INSERT INTO pipeline_data(survey_date, pipeline_id, time, signal, date_ins)" +
                                            "VALUES(@survey_date, @pipeline_id, @time, @signal, DATETIME('now'))";

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

        public void createDatabase()
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

        public void connectToDatabase(string password="")
        {
            if (this.dbConnection == null || this.dbConnection.State.ToString() != "Open" )
            {
                Console.WriteLine("Trying to connect to database....\n");
                this.dbConnection = new SQLiteConnection(string.Format(connectionStingTemplate, this.database, password));
                this.dbConnection.Open();
                Console.WriteLine("Connected to database....\n");
            }
            
        }

        public void createTable()
        {
            //check that connection to db exists
            if (this.dbConnection == null)
                connectToDatabase(this.database);
            Console.WriteLine("Trying to create table....\n");
            string sql = "create table IF NOT EXISTS pipeline_data (ID INTEGER PRIMARY KEY AUTOINCREMENT, survey_date DATETIME not null," +
                                                                    "pipeline_id int not null, time BLOB not null, signal BLOB not null, date_ins DATETIME not null)";
            SQLiteCommand command = new SQLiteCommand(sql, this.dbConnection);
            command.ExecuteNonQuery();
            Console.WriteLine("Table created.\n");            
        }

        public int uploadData(DateTime survey_date, int pipeline_id, ref byte[] time, ref byte[] signal)
        {
            try
            {
                var cmd = new SQLiteCommand(this.insertQuery, this.dbConnection);
                cmd.Parameters.AddWithValue("@time", time);
                cmd.Parameters.AddWithValue("@signal", signal);
                cmd.Parameters.AddWithValue("@pipeline_id", pipeline_id);
                cmd.Parameters.AddWithValue("@survey_date", survey_date);
                return cmd.ExecuteNonQuery();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return 0;
            }
        }
        public void CloseConnection()
        {
            if (this.dbConnection != null)
            {
                this.dbConnection.Close();
                this.dbConnection = null;
            }
        }

    }
}
