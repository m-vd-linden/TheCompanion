using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Threading;

namespace DanceModule
{
    using System.Windows;
    public class DutchFlag
    {
        public async void Send(Window window)
        {
            //Console.WriteLine(a);

            window.Background = System.Windows.Media.Brushes.Red;
            await Task.Delay(1000);
            window.Background = System.Windows.Media.Brushes.White;
            await Task.Delay(1000);
            window.Background = System.Windows.Media.Brushes.Blue;
            await Task.Delay(1000);
            window.Background = System.Windows.Media.Brushes.White;
        }
    }
}
