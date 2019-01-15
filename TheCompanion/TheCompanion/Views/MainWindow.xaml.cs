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
using TheCompanion.Util;
using TheCompanion.Classes;

namespace TheCompanion.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Robot> listofRobots;
        User mainUser;
        DatabaseHandler dbh = new DatabaseHandler();

        public MainWindow(User user)
        {
            InitializeComponent();
            mainUser = user;
            LoadRobots();
        }

        private void LoadRobots()
        {
            dbh.OpenConnection();
            listofRobots = dbh.GetAllRobotsPerUser(mainUser.UserID);
            dbh.CloseConnection();

            for (int i = 0; i < listofRobots.Count; i++)
            {
                RowDefinition rowDefinition = new RowDefinition();
                rowDefinition.Height = new GridLength(1, GridUnitType.Auto);

                grid_Robots.RowDefinitions.Add(rowDefinition);
            }

            for (int i = 0; i < grid_Robots.RowDefinitions.Count; i++)
            {
                Image img = new Image();
                img.Width = 75;
                img.Height = 75;
                img.Margin = new Thickness(10, 10, 0, 10);

                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri("pack://application:,,,/Resources/Logo.png");
                bitmap.EndInit();

                img.Source = bitmap;
                img.MouseUp += chooseRobot_MouseUp;

                Label lbl = new Label();
                lbl.Content = listofRobots[i].Name;
                lbl.FontSize = 20;
                lbl.VerticalAlignment = VerticalAlignment.Center;

                Grid.SetColumn(lbl, 1);
                Grid.SetRow(lbl, i);
                Grid.SetColumn(img, 0);
                Grid.SetRow(img, i);

                grid_Robots.Children.Add(img);
                grid_Robots.Children.Add(lbl);
            }
        }

        private void chooseRobot_MouseUp(object sender, MouseButtonEventArgs e)
        {
            tab_Main.SelectedIndex = 1;
        }
    }
}
