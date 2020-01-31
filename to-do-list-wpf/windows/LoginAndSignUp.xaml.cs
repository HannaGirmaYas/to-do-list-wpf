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
        //Instance's Of FireBase Class 
        FBToDo fb = new FBToDo();
        
        List<User> allusers;
        public LoginAndSignUp()
        {
            
            
            InitializeComponent();
        }
        
        //SignUp Button Event Handler
        private void ClickSignUp(object sender, RoutedEventArgs e)
        {
            if (!fb.Connect()) {
                MessageBox.Show("No connection");
            }
            if (!Validate(usernameR) || !Validate(passwordR) || !Validate(email) || !IsValidEmail(email.Text))
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
                            if (usernameR.Text == userl.Username)
                            {
                                usernameR.Text = "Occupied Username";
                                return;
                            }
                        }
                    }
                }
                Morning_Bell.Task task = new Morning_Bell.Task();
                int count = 0;
                int hashPassword = passwordR.Text.GetHashCode();
                bool loggedIn = false;
                User newUser = new User(usernameR.Text,hashPassword,count,email.Text,task,loggedIn);
                Task<User> x = fb.AddUser(newUser);
                User user = x.Result;


                if (user.Username==newUser.Username)
                {
                    //Next page
                    Login(user);
                    
                } 
            }
         }

        //Login Button Event Handler
       private void ClickLogin(object sender, RoutedEventArgs e){
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
                User u = IsUser(usernameL);
                if (u != null)
                {
                    if (u.Password != passwordL.Text.GetHashCode()) {
                        passwordL.Text = "Incorrect Password";
                    }
                    Login(u);
                }
                usernameL.Text = "No user with that username";
            }
            

        }
       
       
        //Close Window
        private void ClickClose(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        //Skips without Authentication
        private void ClicSkip(object sender, RoutedEventArgs e)
        {
            settings s = new settings();
            s.ShowDialog();
        }


        //Validate's Inputs
        private bool Validate(TextBox x)
        {
            if (string.IsNullOrWhiteSpace(x.Text) )
            {
                x.Text = "Invalid Input";
                return false;
            }
            return true;
        }
        //Login Helper Function
        private void Login(User u) {
            bool t=fb.LoginUser(u);
            if (t)
            {
                settings s = new settings();
                this.Close();
                s.Show();
            }
            else {
                MessageBox.Show("Error");
            }
            


        }
        //Validates if User of username is a Signed Up User
        private User IsUser(TextBox x) {
            allusers = fb.GetAllUsers();
            Console.WriteLine(allusers.Count + "here");
            if (allusers != null)
            {
                foreach (var user in allusers)
                {
                    if (user != null){
                        
                        if (x.Text == user.Username)
                        {
                            
                            return user;
                        }
                        
                    }
                    
                }
            }
            return null;
        }

        //Checks if Email is a valid email
        bool IsValidEmail(string emailText)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(emailText);
                
                return addr.Address == emailText;
            }
            catch
            {
                email.Text = "Invalid Email Address";
                return false;
            }
        }

        //Mouse Action Handler's Hint For Text Box's 

        private void UsernameEnter(object sender, MouseEventArgs e)
        {
            if (usernameL.Text == "Username" || usernameL.Text == "No user with that username" || usernameL.Text == "Invalid Input")
            {
                usernameL.Text = "";
                usernameL.FontStyle = FontStyles.Normal;

            }
        }

        private void PasswordEnter(object sender, MouseEventArgs e)
        {
            if (passwordL.Text == "Password" || passwordL.Text == "Incorrect Password" || passwordL.Text == "Invalid Input")
            {
                passwordL.Text = "";
                passwordL.FontStyle = FontStyles.Normal;

            }
        }

        private void UsernameLeave(object sender, MouseEventArgs e)
        {
            if (usernameL.Text == "")
            {
                usernameL.Text = "Username";
                usernameL.FontStyle = FontStyles.Italic;

            }

        }

        private void PasswordLeave(object sender, MouseEventArgs e)
        {
            if (passwordL.Text == "")
            {
                passwordL.Text = "Password";
                passwordL.FontStyle = FontStyles.Italic;

            }
        }

        private void UsernameEnterR(object sender, MouseEventArgs e)
        {
            if (usernameR.Text == "Username" || usernameR.Text == "Invalid Input"|| usernameR.Text == "Occupied Username")
            {
                usernameR.Text = "";
                usernameR.FontStyle = FontStyles.Italic;

            }
        }

        private void UsernameLeaveR(object sender, MouseEventArgs e)
        {
            if (usernameR.Text == "")
            {
                usernameR.Text = "Username";
                usernameR.FontStyle = FontStyles.Italic;

            }
        }

        private void EmailLeave(object sender, MouseEventArgs e)
        {
            if (email.Text == "")
            {
                email.Text = "Email";
                email.FontStyle = FontStyles.Italic;

            }
        }

        private void EmailEnter(object sender, MouseEventArgs e)
        {
            if (email.Text == "Email"|| email.Text == "Invalid Email Address"|| email.Text == "Invalid Input")
            {
                email.Text = "";
                email.FontStyle = FontStyles.Normal;

            }
        }

        private void passEnter(object sender, MouseEventArgs e)
        {
            if (passwordR.Text == "Password" || passwordR.Text == "Invalid Input")
            {
                passwordR.Text = "";
                passwordR.FontStyle = FontStyles.Italic;

            }
        }

        private void passLeave(object sender, MouseEventArgs e)
        {
            if (passwordR.Text == "")
            {
                passwordR.Text = "Password";
                passwordR.FontStyle = FontStyles.Italic;

            }
        }
    }
}
