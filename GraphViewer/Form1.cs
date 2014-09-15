using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.IO;
using System.Data.SQLite;
using DBManager = DatabaseManager.DatabaseManager;

namespace GraphViewer
{
    public partial class Form1 : Form
    {
        SQLiteConnection m_dbConnection;
        public Form1()
        {
            InitializeComponent();
            InitializeOpenFileDialog();
        }

        private void InitializeOpenFileDialog()
        {
            // Set the file dialog to filter for graphics files. 
            openFileDialog1.Filter =
                "Images (*.csv)|*.csv";

            // Allow the user to select files. 
            openFileDialog1.Multiselect = true;
            openFileDialog1.Title = "Select files to plot";
            openFileDialog1.FileName = "";
        }

        private void generateSeriesFromFile(String filename)
        {
            //var reader = new StreamReader(File.OpenRead(@"C:\Users\Utsav\Desktop\200 Hours Test Data\200 Hours Test Data\scope_1.csv"));
            var reader = new StreamReader(File.OpenRead(filename));
            string seriesName = filename.Substring(filename.LastIndexOf('\\'));
            
            chart1.Series.Add(seriesName);
            chart1.Series[seriesName].ChartType = SeriesChartType.FastLine;

            Random randomGen = new Random();
            KnownColor[] names = (KnownColor[])Enum.GetValues(typeof(KnownColor));
            KnownColor randomColorName = names[randomGen.Next(names.Length)];
            Color randomColor = Color.FromKnownColor(randomColorName);

            chart1.Series[seriesName].Color = randomColor;
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(',');

                try
                {
                    double time = Convert.ToDouble(values[0]);
                    double signal = Convert.ToDouble(values[1]);
                    chart1.Series[seriesName].Points.AddXY(time, signal);
                }
                catch (FormatException)
                {
                    continue;
                }
            }
        }

        private void closeApp_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void generateChart_Click(object sender, EventArgs e)
        {
            chart1.Series.Clear();

            DialogResult dr = openFileDialog1.ShowDialog();

            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                foreach (String file in openFileDialog1.FileNames)
                {
                    generateSeriesFromFile(file);
                }
            }
        }

        private void closeApp_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void createDatabase_Click(object sender, EventArgs e)
        {

        }

        private void uploadData_Click(object sender, EventArgs e)
        {
            Form uploadForm = new uploadDataForm();
            uploadForm.Show();
        }
    }
}
