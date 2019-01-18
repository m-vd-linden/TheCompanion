using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Threading;

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
        DispatcherTimer timer = new DispatcherTimer();
        SerialHandler serial = new SerialHandler();

        public MainWindow(User user)
        {
            InitializeComponent();
            //timer.Interval = new TimeSpan(0, 0, 0, 0, 10);
            //timer.Start();
            //timer.Tick += Timer_Tick;  
            mainUser = user;
            LoadRobots();
        }

        /// <summary>
        /// Method for handling the timer tick
        /// Every tick will be checked if there are new messages send to the pc via serial communication
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer_Tick(object sender, EventArgs e)
        {
            string[] messages = serial.ReadMessages();
            if (messages != null)
            {
                foreach (string message in messages)
                {
                    string result = serial.processReceivedMessage(message);

                    if (result != null)
                    {
                        MessageBox.Show(result);
                    }
                }
            }
        }

        /// <summary>
        /// Methode die het inladen van de robots afhandelt
        /// Per robot wordt er een row aangemaakt met daarin een afbeelding en de naam van de robot
        /// </summary>
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

        /// <summary>
        /// Methode die het kiezen van de desbetreffende robot afhandelt
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chooseRobot_MouseUp(object sender, MouseButtonEventArgs e)
        {
            chosenRobot = (Robot)(((Image)sender).Tag);
            tab_Main.SelectedIndex = 1;
        }

        /// <summary>
        /// Methode die het switchen van tabje afhandelt
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                    LoadStats();
                    break;

                default:
                    break;
            }
        }

        /// <summary>
        /// Method for loading in the stats of all modules
        /// </summary>
        private void LoadStats()
        {
            grid_Stats.RowDefinitions.Clear();

            RowDefinition row = new RowDefinition();
            row.Height = new GridLength(40, GridUnitType.Pixel);

            grid_Stats.RowDefinitions.Add(row);

            Label lbl_Title = new Label();
            lbl_Title.FontSize = 20;
            lbl_Title.Content = "Skill van een module (1/9)";

            Grid.SetRow(lbl_Title, 0);
            Grid.SetColumn(lbl_Title, 0);
            Grid.SetColumnSpan(lbl_Title, 3);

            grid_Stats.Children.Add(lbl_Title);

            for (int i = 0; i < listofModules.Count; i++)
            {
                RowDefinition rowDefinition = new RowDefinition();
                rowDefinition.Height = new GridLength(40, GridUnitType.Pixel);

                grid_Stats.RowDefinitions.Add(rowDefinition);
            }

            RowDefinition rowDefinitionBottom = new RowDefinition();
            rowDefinitionBottom.Height = new GridLength(100, GridUnitType.Star);
            grid_Stats.RowDefinitions.Add(rowDefinitionBottom);

            for (int i = 0; i < listofModules.Count; i++)
            {
                Label lbl = new Label();
                lbl.Content = listofModules[i].Name;

                ProgressBar progressBar = new ProgressBar();
                progressBar.Minimum = 0;
                progressBar.Maximum = 9;
                progressBar.Value = listofModules[i].Skill;
                progressBar.Width = 120;

                Grid.SetRow(lbl, i + 1);
                Grid.SetRow(progressBar, i + 1);
                Grid.SetColumn(lbl, 0);
                Grid.SetColumn(progressBar, 1);

                grid_Stats.Children.Add(lbl);
                grid_Stats.Children.Add(progressBar);
            }
        }

        /// <summary>
        /// Methode die het inladen van de modules afvangt
        /// Eerst worden de modules ingelezen vanuit de database, daarna wordt er per een module een row in de grid aangemaakt
        /// Daarna worden deze rows om en om gevuld met een button om de module uit te voeren
        /// </summary>
        private void LoadModules()
        {
            List<Button> listofDeletableButtons = new List<Button>();
            grid_Modules.RowDefinitions.Clear();
            dbh.OpenConnection();
            listofModules = dbh.GetAllModulesForRobot(chosenRobot.ID);
            dbh.CloseConnection();

            foreach (Button b in grid_Modules.Children.OfType<Button>())
            {
                listofDeletableButtons.Add(b);
            }

            foreach (Button b in listofDeletableButtons)
                grid_Modules.Children.Remove(b);

            for (int i = 0; i < listofModules.Count; i++)
            {
                RowDefinition rowDefinition = new RowDefinition();
                rowDefinition.Height = new GridLength(40, GridUnitType.Pixel);

                grid_Modules.RowDefinitions.Add(rowDefinition);
            }

            RowDefinition rowDefinitionBottom = new RowDefinition();
            rowDefinitionBottom.Height = new GridLength(100, GridUnitType.Star);
            grid_Modules.RowDefinitions.Add(rowDefinitionBottom);

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

            Grid.SetRowSpan(dock_Robot, grid_Modules.RowDefinitions.Count);

        }

        /// <summary>
        /// Methode die het uitvoeren van een module afhandelt
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void moduleButton_Click(object sender, RoutedEventArgs e)
        {
            List<string> listofActions;
            Module module = (Module)(((Button)sender).Tag);

            listofActions = module.Execute();

            foreach (string item in listofActions)
            {
                serial.SendMessage(item);
            }

            module.Upgrade();
            dbh.OpenConnection();
            dbh.UpgradeModule(chosenRobot.ID, module.ID, module.Skill);
            dbh.CloseConnection();
        }

        private void Btn_Stats_Click(object sender, RoutedEventArgs e)
        {
            tab_Main.SelectedIndex = 2;
        }

        /// <summary>
        /// Methode die een nieuwe module kopieert naar de modules map en daarnaast deze in de database toevoegt
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_AddModule_Click(object sender, RoutedEventArgs e)
        {
            string moduleName;
            string fileName;
            string fileLocation;

            AddWindow addWindow = new AddWindow();
            addWindow.ShowDialog();

            moduleName = addWindow.ModuleName;
            fileName = addWindow.ModuleLocation;
            fileLocation = addWindow.FullModuleLocation;

            File.Copy(fileLocation, AppDomain.CurrentDomain.BaseDirectory + fileName);

            dbh.OpenConnection();
            dbh.AddModule(moduleName, fileName, chosenRobot.ID);
            dbh.CloseConnection();

            LoadModules();
        }

        /// <summary>
        /// Method for handling the home button click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Home_Click(object sender, RoutedEventArgs e)
        {
            tab_Main.SelectedIndex = 0;
        }
    }
}
