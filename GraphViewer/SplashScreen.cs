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
    public partial class SplashScreen : Form
    {
        System.Windows.Forms.Timer t = new System.Windows.Forms.Timer();  
  
        public SplashScreen()  
        {  
            InitializeComponent();  
            SetAndStartTimer();  
        }  
  
        private void SetAndStartTimer()  
        {  
            t.Interval = 2000;  
            t.Tick += new EventHandler(t_Tick);  
            t.Start();  
        }  
  
        void t_Tick(object sender, EventArgs e)  
        {  
            this.Close();  
        }  
    }
}
