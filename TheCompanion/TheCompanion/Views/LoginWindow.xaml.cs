using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
using TheCompanion.Classes;
using TheCompanion.Util;
using TheCompanion.Views;

namespace TheCompanion
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        DatabaseHandler dbh = new DatabaseHandler();

        public LoginWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Method for handling the login click event
        /// If a username and password exists in the database the user will be logged in
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            dbh.OpenConnection();
            Tuple<bool, int, string> tuple = dbh.Login(txtb_Username.Text, CreateHash(pswd_Password.Password));

            if (tuple.Item1)
            {
                User user = new User(tuple.Item2, tuple.Item3);
                dbh.CloseConnection();
                MainWindow main = new MainWindow(user);
                this.Hide();
                main.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Inloggegevens zijn incorrect");
            }
        }

        /// <summary>
        /// Method for hashing the MD5 hashing the password of a user
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private string CreateHash(string input)
        {
            MD5 md5 = MD5.Create();

            byte[] inputInBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hashedInput = md5.ComputeHash(inputInBytes);

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < hashedInput.Length; i++)
            {
                sb.Append(hashedInput[i].ToString("X2"));
            }
            return sb.ToString();

        }

        public void Txtb_Username_GotFocus(object sender, RoutedEventArgs e)
        {
            (sender as System.Windows.Controls.TextBox).SelectAll();
        }

        public void txtb_Password_GotFocus(object sender, RoutedEventArgs e)
        {
            (sender as System.Windows.Controls.PasswordBox).SelectAll();
        }
    }
}
