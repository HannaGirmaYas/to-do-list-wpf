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
using Morning_Bell;
using to_do_list_wpf.Models;

namespace to_do_list_wpf.windows
{
    /// <summary>
    /// Interaction logic for LoginAndSignUp.xaml
    /// </summary>
    public partial class LoginAndSignUp : Window
    {
        FBToDo fb = new FBToDo();
        User user;
        Users users;
        public LoginAndSignUp()
        {
            InitializeComponent();
        }
        bool IsString(object value)
        {
            return value is string;
        }

        private void ClickSignUp(object sender, RoutedEventArgs e)
        {
            if (!fb.Connect()) {
                MessageBox.Show("No connection");
            }
            if (!Validate(usernameR) || !Validate(passwordR) || !Validate(email))
            {
                return;
            }
            else {
                string taskID = RandomTaskID(usernameR.Text);
                int hashPassword = passwordR.Text.GetHashCode();
                User newUser = new User(usernameR.Text, hashPassword, email.Text, taskID);
                Task<User> x = fb.AddUser(newUser);

                User user = x.Result;
                if (user.Equals(newUser))
                {
                    MessageBox.Show("iS EQUAL");
                    Settings s = new Settings();
                    s.Show();
                    this.Close();
                }

            }
             /*users =fb.GetAllUsers(); 
             if (users != null) {
                 if (usernameR.Text != users.User.Length)
                 {
                     usernameR.Text = "Occupied Username";
                 }
             }
             //if (allUsers != null) {
               //  foreach (var u in allUsers)
               //  {

                // }
            // }*/


        }

        private void ClicSkip(object sender, RoutedEventArgs e)
        {

        }

        private void ClickLogin(object sender, RoutedEventArgs e)
        {
            if (!fb.Connect())
            {
                MessageBox.Show("No connection");
            }
            if (!Validate(usernameL) ||
            !Validate(passwordL))
            {
                return;
            }
            else {
                user = fb.GetUser(usernameL.Text);
                if (user != null)
                {
                    if (user.Password != passwordL.Text.GetHashCode())
                    {
                        passwordL.Text = "Invalid Password";
                    }
                }
                else
                {
                    MessageBox.Show("No user with that Username");
                }
                MessageBox.Show("Logging In");
            }
            

        }
        private bool Validate(TextBox x) {
            if (string.IsNullOrWhiteSpace(x.Text) || !IsString(x.Text))
            {
                x.Text = "Invalid Input";
                return false;
            }
            return true;
        }
        public string RandomTaskID(string username)
        {
            Random random = new Random();
            int x= random.Next(0, 1000);
            string taskID = username + x.ToString();
            return taskID;
        }

        private void ClickClose(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
