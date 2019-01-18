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

        /// <summary>
        /// Method for handling the add module button click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_AddModule_Click(object sender, RoutedEventArgs e)
        {
            if (txtb_ModuleName.Text != "" && txtb_ModuleLocation.Text != "")
            {
                ModuleName = txtb_ModuleName.Text;

                this.Close();
            }
        }

        /// <summary>
        /// Method for handling the browse module click event
        /// Opening a file dialog where the user can select a new module
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
