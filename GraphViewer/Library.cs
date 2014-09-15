using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utility = Utils.Utils;
using DBManager = DatabaseManager.DatabaseManager;

namespace GraphViewer
{
    class Library
    {
        private static string dbName = @"testDatabase.sqlite";

        public static bool uploadCsvData(string filename, DateTime date, int pipeLine)
        {
            List<double> t = new List<double>();
            List<double> s = new List<double>();

            Utility.readCsvFile(filename,ref t,ref s);

            byte[] time = Utility.getByteArray(t.ToArray());
            byte[] signal = Utility.getByteArray(s.ToArray());

            DBManager db = DBManager.getInstance( dbName );

            try
            {
                //create the database
                db.createDatabase();
                //open the connetion
                db.connectToDatabase();
                //create the table
                db.createTable();
                //upload data
                db.uploadData(date, pipeLine, ref time, ref signal);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }            
        }
    }
}
