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
        SerialHandler serial = new SerialHandler();

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
            dbh.OpenConnection();
            listofModules = dbh.GetAllModulesForRobot(chosenRobot.ID);
            dbh.CloseConnection();

            for (int i = 0; i < listofModules.Count; i++)
            {
                RowDefinition rowDefinition = new RowDefinition();
                rowDefinition.Height = new GridLength(40, GridUnitType.Pixel);

                grid_Modules.RowDefinitions.Add(rowDefinition);
            }

            RowDefinition rowDefinitionBottom = new RowDefinition();
            rowDefinitionBottom.Height = new GridLength(100, GridUnitType.Star);
            grid_Modules.RowDefinitions.Add(rowDefinitionBottom);

            stack_ImgChallengeButton.Height = grid_Modules.Height;
            Grid.SetRowSpan(stack_ImgChallengeButton, grid_Modules.RowDefinitions.Count);


            for (int i = 0; i < listofModules.Count; i+=2)
            {
                Button btn = new Button();
                btn.Content = listofModules[i].Name;
                btn.Tag = listofModules[i];
                btn.Click += moduleButton_Click;
                btn.FontSize = 20;
                btn.VerticalAlignment = VerticalAlignment.Top;
                btn.Height = 40;
                btn.Margin = new Thickness(20, 0, 30, 0);

                Grid.SetRow(btn, i);
                Grid.SetColumn(btn, 0);
                grid_Modules.Children.Add(btn);

                if (listofModules.Count - i > 1)
                {
                    Button btn2 = new Button();
                    btn2.Content = listofModules[i + 1].Name;
                    btn2.Tag = listofModules[i + 1];
                    btn2.Click += moduleButton_Click;
                    btn2.FontSize = 20;
                    btn2.VerticalAlignment = VerticalAlignment.Top;
                    btn2.Height = 40;
                    btn2.Margin = new Thickness(20, 0, 30, 0);

                    Grid.SetRow(btn2, i + 1);
                    Grid.SetColumn(btn2, 2);
                    grid_Modules.Children.Add(btn2);
                }
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

            serial.SendMessage("EEN");
        }

        private void btn_Challenges_Click(object sender, RoutedEventArgs e)
        {
            //tab_Main.SelectedIndex = 2;
            serial.SendMessage("TWEE");
        }
    }
}
