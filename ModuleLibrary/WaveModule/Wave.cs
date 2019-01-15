using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WaveModule
{
    public class GermanFlag
    {
        public async void Send(Window window)
        {
            //Console.WriteLine(a);

            window.Background = System.Windows.Media.Brushes.Black;
            await Task.Delay(1000);
            window.Background = System.Windows.Media.Brushes.Red;
            await Task.Delay(1000);
            window.Background = System.Windows.Media.Brushes.Yellow;
            await Task.Delay(1000);
            window.Background = System.Windows.Media.Brushes.White;

        }
    }
}
