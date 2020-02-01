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
using to_do_list_wpf.Model;

namespace to_do_list_wpf.windows
{
    /// <summary>
    /// Interaction logic for settings.xaml
    /// </summary>
    public partial class settings : Window
    {
        FBToDo fb = new FBToDo();
        public settings() {
            InitializeComponent();
        }
        public settings(string usernameL)
        {

            User u = fb.GetUser(usernameL);
            if (u == null) { throw new Exception("User Null"); }
            if (u.LoggedIn == true) {
                login.Visibility = Visibility.Collapsed;
                signUp.Visibility = Visibility.Collapsed;
                signin.Visibility = Visibility.Collapsed;
                username.Text = u.Username;
                email.Text = u.Email;
                username.Visibility = Visibility.Visible;
                email.Visibility = Visibility.Visible;
                sync.Visibility = Visibility.Visible;
                signOut.Visibility = Visibility.Visible;
                
            }
            InitializeComponent();
        }

        private void ClickSignOut(object sender, RoutedEventArgs e)
        {

        }

        private void ClickSync(object sender, RoutedEventArgs e)
        {

        }

        private void ClickSignUp(object sender, RoutedEventArgs e)
        {
            LoginAndSignUp ls = new LoginAndSignUp();
            ls.ShowDialog();
        }

        private void ClickLogin(object sender, RoutedEventArgs e)
        {
            LoginAndSignUp ls = new LoginAndSignUp();
            ls.ShowDialog();
        }
    }
}
