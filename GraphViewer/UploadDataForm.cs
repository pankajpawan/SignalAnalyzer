using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace GraphViewer
{
    public partial class uploadDataForm : Form
    {
        public uploadDataForm()
        {
            InitializeComponent();
            InitializeOpenFileDialog();
            
            this.Load += new EventHandler(uploadDataForm_Load);        
        }

        private void uploadDataForm_Load(object sender, EventArgs e)
        {
            this.AutoValidate = AutoValidate.Disable;

        }

        private void InitializeOpenFileDialog()
        {
            openFileDialog1.Filter =
                "Images (*.csv)|*.csv";

            // Allow the user to select files. 
            openFileDialog1.Multiselect = false;
            openFileDialog1.Title = "Select file to upload";
            openFileDialog1.FileName = "";
        }

        private void uploadFileName_Enter(object sender, EventArgs e)
        {
            DialogResult dr = openFileDialog1.ShowDialog();

            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                uploadFileName.Text = openFileDialog1.FileName;
            }
        }
        private void uploadToDatabaseButton_Click(object sender, EventArgs e)
        {
            //check validation
            if (!this.ValidateChildren())
                return;
            bool status = Library.uploadCsvData(uploadFileName.Text, dateTimePicker1.Value, Convert.ToInt32(pipeLineID.Text));

            if (status)
            {
                MessageBox.Show("Data successfully uploaded");
                this.Close();
            }             
            else
                MessageBox.Show("upload failed");
        }

        private void pipeLineID_Validating(object sender, CancelEventArgs e)
        {
            if (!(Regex.IsMatch(pipeLineID.Text, @"^\d{4}$")))
            {
                e.Cancel = true;
                pipeLineID.Select(0, pipeLineID.Text.Length);
                errorProvider1.SetError(pipeLineID, "Please enter a 4 digit number only");
            }
            else
            {
                errorProvider1.SetError(pipeLineID, "");
            }
        }

        private void cancelUpload_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void uploadFileName_Validating(object sender, CancelEventArgs e)
        {
            if (uploadFileName.Text.Length == 0 || !File.Exists(uploadFileName.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(selectUploadFile, "Please select a valid file");
            }
            else
            {
                errorProvider1.SetError(selectUploadFile, "");
            }
        }         
    }
}
