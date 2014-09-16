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

        public int pipeline;
        public string filename;
        public DateTime survey_date;

        public SelectMetaInfo()
        {
            InitializeComponent();
            try
            {
                DBManager db = DBManager.getInstance(dbName);
                SQLiteDataAdapter da = db.fetchMetaInfo();

                //DataTable ds = new DataTable();
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

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            //// ... get selecteditems from datagrid.
            //var grid = sender as DataTable;

            DataGridViewRow selected = dataGridView1.SelectedRows[0];
            this.survey_date = (DateTime)selected.Cells[0].Value;// as DateTime;
            this.filename = (string)selected.Cells[3].Value;
            this.pipeline = (int)selected.Cells[1].Value;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
