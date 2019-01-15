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
        List<Module> listofModules;
        Robot chosenRobot;
        User mainUser;
        DatabaseHandler dbh = new DatabaseHandler();
        Module script = new Module("Dance", "HelloModule.dll");

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
                img.Tag = listofRobots[i];

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
            chosenRobot = (Robot)(((Image)sender).Tag);
            tab_Main.SelectedIndex = 1;
            //Console.WriteLine(chosenRobot.Name);

            //script.Execute();
        }

        private void Tab_Main_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (tab_Main.SelectedIndex)
            {
                case 0:
                    break;

                case 1:
                    LoadModules();
                    break;

                case 2:
                    break;

                default:
                    break;
            }
        }

        private void LoadModules()
        {
            stackie.Children.Clear();
            dbh.OpenConnection();
            listofModules = dbh.GetAllModulesForRobot(chosenRobot.ID);
            dbh.CloseConnection();

            foreach (Module module in listofModules)
            {
                Button btn = new Button();
                btn.Content = listofModules[0].Name;
                btn.Tag = listofModules[0];
                btn.Click += moduleButton_Click;

                stackie.Children.Add(btn);
            }
        }

        private void moduleButton_Click(object sender, RoutedEventArgs e)
        {
            List<string> listofActions;
            Module module = (Module)(((Button)sender).Tag);

            listofActions = module.Execute();

            foreach (string item in listofActions)
            {
                Console.WriteLine(item);
            }
        }
    }
}
