using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp6
{
    public partial class ctrlCalculator : UserControl
    {
        public ctrlCalculator()
        {
            InitializeComponent();
        }


        public event Action<int> OnCalculationComplete;

        protected virtual void CalculationComplete(int res)
        {
            Action<int> handler = OnCalculationComplete;
            if (handler != null)
            {
                handler(res);
            }
        }

        private void btnCalc_Click(object sender, EventArgs e)
        {
            int res = int.Parse(txtValue1.Text.ToString()) + int.Parse(txtValue2.Text.ToString());

            txtResult.Text = res.ToString();

            if(OnCalculationComplete != null)
                CalculationComplete(res);
        }
    }
}
