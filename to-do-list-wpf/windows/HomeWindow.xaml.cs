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

namespace to_do_list_wpf.windows
{
    /// <summary>
    /// Interaction logic for HomeWindow.xaml
    /// </summary>
    public partial class HomeWindow : Window
    {
        string username;
        public HomeWindow(string username)
        {
            
            InitializeComponent();
            this.username = username;
			this.MouseDown += (sender, e) => {
				if (e.LeftButton == MouseButtonState.Pressed) {
					this.DragMove();
				}
			};

			MainPage1 p = new MainPage1(username);
            mainFrame.Navigate(p);

        }

        private void addTaskButton_Click(object sender, RoutedEventArgs e)
        {

            TaskViewWindow w = new TaskViewWindow(username,new Model.to_doTask());
            w.Show();
            //call window
        }

        private void settingButton_Click(object sender, RoutedEventArgs e)
        {
            //call setting
            SettingsPage1 p = new SettingsPage1();
            mainFrame.Navigate(p);
        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void minimizeButton_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
    }
}
