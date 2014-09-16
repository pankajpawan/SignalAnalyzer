using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DBManager = DatabaseManager.DatabaseManager;
namespace GraphViewer
{
    public partial class SelectMetaInfo : Form
    {
        private static string dbName = @"testDatabase.sqlite";
        public SelectMetaInfo()
        {
            InitializeComponent();
            try
            {
                DBManager db = DBManager.getInstance(dbName);
                SQLiteDataAdapter da = db.fetchMetaInfo();

                DataSet ds = new DataSet();
                da.Fill(ds);
                
                
                dataGridView1.DataSource = ds.Tables[0].DefaultView;
                dataGridView1.Show();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
