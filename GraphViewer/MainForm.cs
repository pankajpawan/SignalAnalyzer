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
    public partial class MainForm : Form
    {
        SQLiteConnection m_dbConnection;
        private int pipeline;
        private string filename;
        private DateTime survey_date;

        public MainForm()
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
            chart1.Hide();
        }

        private void generateSeriesFromFile(String filename, DateTime survey_date, int pipeline = 0)
        {
            //var reader = new StreamReader(File.OpenRead(@"C:\Users\Utsav\Desktop\200 Hours Test Data\200 Hours Test Data\scope_1.csv"));
            var reader = new StreamReader(File.OpenRead(filename));

            string seriesName;
            Color randomColor;
            if (pipeline == 0)
            {
                seriesName = filename.Substring(filename.LastIndexOf('\\'));
                Random randomGen = new Random();
                KnownColor[] names = (KnownColor[])Enum.GetValues(typeof(KnownColor));
                KnownColor randomColorName = names[randomGen.Next(names.Length)];
                randomColor = Color.FromKnownColor(randomColorName);
            }
            else
            {
                seriesName = survey_date.ToString() + @"|" + pipeline.ToString();
                var random = new Random();
                string color = String.Format("#{0:X6}", random.Next(0x1000000) & 0x7F7F7F);
                randomColor = System.Drawing.ColorTranslator.FromHtml(color);
            }
            
            chart1.Series.Add(seriesName);
            chart1.Series[seriesName].ChartType = SeriesChartType.FastLine;

            

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
            chart1.Show();
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
                    generateSeriesFromFile(file, DateTime.Today);
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
            uploadForm.ShowDialog();
        }

        private void selectDateandPipeline_Click(object sender, EventArgs e)
        {
            SelectMetaInfo metaInfo = new SelectMetaInfo();
            if (metaInfo.ShowDialog() == DialogResult.OK)
            {
                this.pipeline = metaInfo.pipeline;
                this.survey_date = metaInfo.survey_date;
                this.filename = metaInfo.filename;

                chart1.Series.Clear();

                generateSeriesFromFile(this.filename, this.survey_date, this.pipeline);
                chart1.Show();
            }
            else
            {
                MessageBox.Show("No plot selected for plotting");
            }
            
        }

        private void homeScreen_Click(object sender, EventArgs e)
        {
            chart1.Hide();
        }
    }
}
