using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using to_do_list_wpf.Model;
namespace to_do_list_wpf.windows
{
	/// <summary>
	/// Interaction logic for MainPage1.xaml
	/// </summary>
	public partial class MainPage1 : Page
	{
		public ObservableCollection<to_doTask> TaskList { get; set; }
        FBToDo fb = new FBToDo();
        string username;
        public MainPage1(string username) {
			TaskList = new ObservableCollection<to_doTask>();
			TaskList.Add(new to_doTask("task1"));
			TaskList.Add(new to_doTask("task2"));
			TaskList.Add(new to_doTask("task3"));
			TaskList.Add(new to_doTask("task4"));
			TaskList.Add(new to_doTask("task5"));

			// replace the binding by user or something
			this.DataContext = this;
			InitializeComponent();
            this.username = username;
		}

		private void searchButton_Click(object sender, RoutedEventArgs e) {
            string title = searchedElement.Text;
            if (title == "")
            {
                MessageBox.Show("Please enter Title of the task");
                return;
            }
            to_doTask t= fb.GetTask(username, title);

            //how to display t
        }

		private void deleteTaskButton_Click(object sender, RoutedEventArgs e) {
            //var task = (sender as FrameworkElement).DataContext as to_doTask;
            //foreach (var window in openWindows.ToList()) {
            //	if (window.ContainedTaskEquals(task)) {
            //		window.Close();
            //		RemoveWindow(window);
            //	}
            //}
            // replace this logic to what points to the users.

            //TaskList.Remove(task);

            //uncomment this
            //fb.DeleteTask(username,sender);
            //how to display list
		}
		List<TaskViewWindow> openWindows = new List<TaskViewWindow>();

		private void OpenTask(object sender, MouseButtonEventArgs e) {
			var task = (sender as FrameworkElement).DataContext as to_doTask;
			foreach (var window in openWindows.ToList()) {
				if (window.IsClosed) {
					RemoveWindow(window);
				} else if (window.ContainedTaskEquals(task)) {
					return;
				}
			}
			//openWindows.Add(TaskViewWindow.OpenATaskViewWindow(task));

            //i was thinking we do this instead
            //var task = (sender as FrameworkElement).DataContext as to_doTask;
            //TaskViewWindow  w = new TaskViewWindow(username,task);
            //w.Show();
        }
		private void RemoveWindow(TaskViewWindow window) {
			lock (openWindows) {
				openWindows.Remove(window);
			}
		}
	}
}
