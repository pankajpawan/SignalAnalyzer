namespace GraphViewer
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.closeApp = new System.Windows.Forms.Button();
            this.generateChart = new System.Windows.Forms.Button();
            this.createDatabase = new System.Windows.Forms.Button();
            this.uploadData = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.selectDateandPipeline = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 87F));
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1050, 618);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.flowLayoutPanel1.Controls.Add(this.closeApp);
            this.flowLayoutPanel1.Controls.Add(this.generateChart);
            this.flowLayoutPanel1.Controls.Add(this.createDatabase);
            this.flowLayoutPanel1.Controls.Add(this.uploadData);
            this.flowLayoutPanel1.Controls.Add(this.selectDateandPipeline);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 173);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(130, 210);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // closeApp
            // 
            this.closeApp.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.closeApp.Location = new System.Drawing.Point(3, 3);
            this.closeApp.Name = "closeApp";
            this.closeApp.Size = new System.Drawing.Size(124, 36);
            this.closeApp.TabIndex = 1;
            this.closeApp.Text = "Close App";
            this.closeApp.UseVisualStyleBackColor = true;
            this.closeApp.Click += new System.EventHandler(this.closeApp_Click_1);
            // 
            // generateChart
            // 
            this.generateChart.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.generateChart.Location = new System.Drawing.Point(-1, 45);
            this.generateChart.Name = "generateChart";
            this.generateChart.Size = new System.Drawing.Size(128, 33);
            this.generateChart.TabIndex = 0;
            this.generateChart.Text = "Select files to Plot";
            this.generateChart.UseVisualStyleBackColor = true;
            this.generateChart.Click += new System.EventHandler(this.generateChart_Click);
            // 
            // createDatabase
            // 
            this.createDatabase.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.createDatabase.Location = new System.Drawing.Point(-1, 84);
            this.createDatabase.Name = "createDatabase";
            this.createDatabase.Size = new System.Drawing.Size(128, 33);
            this.createDatabase.TabIndex = 2;
            this.createDatabase.Text = "Create Database";
            this.createDatabase.UseVisualStyleBackColor = true;
            this.createDatabase.Click += new System.EventHandler(this.createDatabase_Click);
            // 
            // uploadData
            // 
            this.uploadData.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.uploadData.Location = new System.Drawing.Point(-1, 123);
            this.uploadData.Name = "uploadData";
            this.uploadData.Size = new System.Drawing.Size(128, 33);
            this.uploadData.TabIndex = 3;
            this.uploadData.Text = "Upload Data";
            this.uploadData.UseVisualStyleBackColor = true;
            this.uploadData.Click += new System.EventHandler(this.uploadData_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.chart1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(139, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(908, 550);
            this.panel1.TabIndex = 2;
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(0, 0);
            this.chart1.Name = "chart1";
            this.chart1.Size = new System.Drawing.Size(908, 550);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // selectDateandPipeline
            // 
            this.selectDateandPipeline.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.selectDateandPipeline.Location = new System.Drawing.Point(-1, 162);
            this.selectDateandPipeline.Name = "selectDateandPipeline";
            this.selectDateandPipeline.Size = new System.Drawing.Size(128, 33);
            this.selectDateandPipeline.TabIndex = 4;
            this.selectDateandPipeline.Text = "Select Date";
            this.selectDateandPipeline.UseVisualStyleBackColor = true;
            this.selectDateandPipeline.Click += new System.EventHandler(this.selectDateandPipeline_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1050, 618);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Plot It!";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);

        }
        
        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button closeApp;
        private System.Windows.Forms.Button generateChart;
        private System.Windows.Forms.Button createDatabase;
        private System.Windows.Forms.Button uploadData;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button selectDateandPipeline;
    }
}

