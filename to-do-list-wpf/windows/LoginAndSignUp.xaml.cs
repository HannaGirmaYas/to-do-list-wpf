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
using FireSharp.Config;
using FireSharp.Response;
using FireSharp.Interfaces;
using to_do_list_wpf.Model;

namespace to_do_list_wpf.windows
{
    /// <summary>
    /// Interaction logic for LoginAndSignUp.xaml
    /// </summary>
    public partial class LoginAndSignUp : Window
    {
        
        FBToDo fb = new FBToDo();
        User user;
        List<User> allusers;
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
              allusers = fb.GetAllUsers();
                if (allusers != null)
                {
                    foreach (var userl in allusers)
                    {
                        if (userl != null)
                        {
                            if (usernameR.Text != userl.Username)
                            {
                                usernameR.Text = "Occupied Username";
                            }
                        }
                    }
                }
                to_doTask task = new to_doTask();
                int count = 0;
                int hashPassword = passwordR.Text.GetHashCode();
                User newUser = new User(usernameR.Text,hashPassword,count,email.Text,task);
                Task<User> x = fb.AddUser(newUser);

                User user = x.Result;
                if (user.Username==newUser.Username)
                {
                   //Next page
                    settings s = new settings();
                    this.Close();
                    s.Show();
                    
                }
}
             
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
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("No user with that Username");
                }
                if (usernameL.Text == user.Username && user.Password == passwordL.Text.GetHashCode()) {
                    MessageBox.Show("Login Successful");
                }
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

        private void ClicSkip(object sender, RoutedEventArgs e)
        {
        }
    }
}
