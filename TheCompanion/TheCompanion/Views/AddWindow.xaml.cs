using Microsoft.Win32;
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
using System.Windows.Shapes;

namespace TheCompanion.Views
{
    /// <summary>
    /// Interaction logic for AddWindow.xaml
    /// </summary>
    public partial class AddWindow : Window
    {

        public string ModuleName
        {
            get; private set;
        }

        public string ModuleLocation
        {
            get; private set;
        }

        public string FullModuleLocation
        {
            get; private set;
        }

        public AddWindow()
        {
            InitializeComponent();
        }

        private void Txtb_ModuleLocation_GotFocus(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_AddModule_Click(object sender, RoutedEventArgs e)
        {
            if (txtb_ModuleName.Text != "" && txtb_ModuleLocation.Text != "")
            {
                ModuleName = txtb_ModuleName.Text;

                this.Close();
            }
        }

        private void Btn_BrowseModule_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Choose module";
            ofd.Filter = " DLL file | *.dll";
            ofd.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;
            Nullable<bool> result = ofd.ShowDialog();

            if (result == true)
            {
                ModuleLocation = ofd.SafeFileName;
                FullModuleLocation = ofd.FileName;
                txtb_ModuleLocation.Text = ofd.FileName;
            }
        }
    }
}
