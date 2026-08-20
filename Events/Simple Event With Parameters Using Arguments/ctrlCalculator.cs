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


        //public event Action<int> OnCalculationComplete;

        //protected virtual void CalculationComplete(int res)
        //{
        //    Action<int> handler = OnCalculationComplete;
        //    if (handler != null)
        //    {
        //        handler(res);
        //    }
        //}

        public class CalcCompleteEventArgs : EventArgs
        {
            public int Val1 { get; }
            public int Val2 { get; }
            public int Result { get; }


            public CalcCompleteEventArgs(int val1, int val2, int result)
            {
                this.Val1 = val1;
                this.Val2 = val2;
                this.Result = result;
            }
        }

        public event EventHandler<CalcCompleteEventArgs> OnCalculationComplete;

        public void RaiseOnCalculationComplete(int val1, int val2, int result) {
            RaiseOnCalculationComplete(new CalcCompleteEventArgs(val1, val2, result));
        }
        protected virtual void RaiseOnCalculationComplete(CalcCompleteEventArgs e)
        {
            OnCalculationComplete?.Invoke(this,e);
        }




        private void btnCalc_Click(object sender, EventArgs e)
        {
            int val1 = Convert.ToInt32(txtValue1.Text);
            int val2 = Convert.ToInt32(txtValue2.Text);
            int result = val1 + val2;

            txtResult.Text = result.ToString();

            RaiseOnCalculationComplete(val1, val2, result); 
            
        }
    }
}
