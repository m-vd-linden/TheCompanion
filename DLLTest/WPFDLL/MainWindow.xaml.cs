using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Reflection;
using Microsoft.Win32;
using System.IO;

namespace WPFDLL
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Assembly dll = Assembly.LoadFile(@"D:\VS 2017\ModuleLibrary\DanceModule\bin\Debug\DanceModule.dll");

        static string startupLocation = AppDomain.CurrentDomain.BaseDirectory;
        public MainWindow()
        {
            InitializeComponent();

            DirectoryInfo d = new DirectoryInfo(startupLocation + @"/Modules");
            FileInfo[] Files = d.GetFiles("*.dll");

            foreach(FileInfo info in Files)
            {
                Console.WriteLine(info.FullName);

                Assembly dll2 = Assembly.LoadFile(info.FullName);

                foreach(Type t in dll2.GetExportedTypes())
                {
                    ListBoxItem lbItem = new ListBoxItem();
                    lbItem.Content = t.Name;
                    lbItem.Tag = info.FullName;
                    lbItem.MouseUp += LbItem_MouseUp;

                    listBox.Items.Add(lbItem);
                }

            }

            foreach (string item in File.ReadAllLines(@"D:\Fontys\Leerjaar 1\Periode 2\OIT\wetransfer-0c8108\Kleuren_Switch.ino"))
            {
                Console.WriteLine(item);
            }
        }

        private void LbItem_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Assembly module = Assembly.LoadFile(((ListBoxItem)sender).Tag.ToString());

            foreach(Type t in module.GetExportedTypes())
            {
                Console.WriteLine(t.Name);

                dynamic d = Activator.CreateInstance(t);

                d.Send(windowMain);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
        //    foreach (Type t in dll.GetExportedTypes())
        //    {
        //        Console.WriteLine(t.Name);

        //        dynamic d = Activator.CreateInstance(t);

        //        d.Send(windowMain);
        //    }
        }
    }
}
