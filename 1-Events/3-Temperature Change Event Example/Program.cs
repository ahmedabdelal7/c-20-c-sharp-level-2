using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Temperature_Change_Event_Example
{
    public class TemperatureChangedEventArgs : EventArgs
    {
        public double OldTemp { get; }
        public double NewTemp { get; }
        public double Difference { get; }

        public TemperatureChangedEventArgs(double oldTemp, double newTemp)
        {
            this.OldTemp = oldTemp;
            this.NewTemp = newTemp;
            this.Difference = newTemp - oldTemp;

        }

    }

    public class Thermostat
    {
        private double OldTemp;
        private double CurrentTemp;

        public event EventHandler<TemperatureChangedEventArgs> OnTemperatureChanged;

        public void SetTemperature(double NewTemp)
        {
            if (CurrentTemp != NewTemp)
            {
                OldTemp = CurrentTemp;
                CurrentTemp = NewTemp;
                TemperatureChanged(OldTemp, CurrentTemp);
            }

        }

        private void TemperatureChanged(double oldTemp , double newTemp)
        {
            TemperatureChanged(new TemperatureChangedEventArgs(OldTemp, newTemp));
        }
        protected virtual void TemperatureChanged(TemperatureChangedEventArgs e)
        {
            OnTemperatureChanged?.Invoke(this, e);
        }
    }

    public class Display
    {
        public void Subscribe(Thermostat t)
        {
            t.OnTemperatureChanged += HandleOnTemperatureChange;
        }

        private void HandleOnTemperatureChange(object sender, TemperatureChangedEventArgs e)
        {
            Console.WriteLine($"Temperature Changed From : {e.OldTemp}");
            Console.WriteLine($"Temperature Changed To   : {e.NewTemp}");
            Console.WriteLine($"Temperature Difference   : {e.Difference}");
            Console.WriteLine();

        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            Thermostat t = new Thermostat();

            Display display = new Display();

            display.Subscribe(t);

            t.SetTemperature(10);
            t.SetTemperature(15);
            t.SetTemperature(15);


            Console.ReadKey();

        }
    }
    
}