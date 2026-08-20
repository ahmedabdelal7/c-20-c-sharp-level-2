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

        private void ctrlCalculator1_OnCalculationComplete(object sender, ctrlCalculator.CalcCompleteEventArgs e)
        {
            lblResult.Text = e.Result.ToString();

            MessageBox.Show($"Value1 = {e.Val1}, Value2 = {e.Val2}, Result = {e.Result}");
        }
    }
}
