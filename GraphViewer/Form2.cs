using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GraphViewer
{
    public partial class uploadDataForm : Form
    {
        public uploadDataForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter =
                "Images (*.csv)|*.csv";

            // Allow the user to select files. 
            openFileDialog1.Multiselect = false;
            openFileDialog1.Title = "Select file to upload";
            openFileDialog1.FileName = "";


            DialogResult dr = openFileDialog1.ShowDialog();

            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                textBox2.Text = openFileDialog1.FileName;
            }
        }

        private void uploadToDatabaseButton_Click(object sender, EventArgs e)
        {

        }
        
    }
}
