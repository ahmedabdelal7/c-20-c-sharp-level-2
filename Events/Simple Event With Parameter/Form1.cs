using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void ctrlCalculator1_OnCalculationComplete(int obj)
        {
            int result = obj;
            //MessageBox.Show($"Result is = {result.ToString()}");
            lblResult.Text = result.ToString();
        }
    }
}
