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
	/// Interaction logic for TaskViewWindow.xaml
	/// </summary>
	public partial class TaskViewWindow : Window
	{
        string username;
        FBToDo fb = new FBToDo();
        public static TaskViewWindow OpenATaskViewWindow(string usern,to_doTask task) {
           
			var window = new TaskViewWindow(usern,task);
			window.task = task;
			window.DataContext = window.task;
			window.Show();
			return window;
		}
		public TaskViewWindow(string username, to_doTask task) {
            this.username = username;
			InitializeComponent();
			this.MouseDown += (sender, e) => {
				if (e.LeftButton == MouseButtonState.Pressed) {
					this.DragMove();
				}
			};
		}

		private to_doTask task;

		private void AddItem(object sender, RoutedEventArgs e) {

            string text="";// = textOfItem.Text;//the text next to checkbox
            if (text.Length == 0)
            {
                MessageBox.Show("please enter text");
                return;
            }
            to_doTask.ChecklistItem c = new to_doTask.ChecklistItem(text);
            fb.AddCheckListItem(username, task.Title, c);
			//this.task.AddNewItem();
		}

		private void RemoveItem(object sender, RoutedEventArgs e) {
            string text="";//=sender as the text or something
            if (text.Length == 0)
            {
                MessageBox.Show("please enter text");
                return;
            }
            
            fb.DeleteCheckListItem(username, task.Title, text);

            //this.task.items.Remove((sender as Button).DataContext as to_doTask.ChecklistItem);
        }

		private void CloseWindow(object sender, RoutedEventArgs e) {
			this.Close();
		}

		public bool ContainedTaskEquals(to_doTask task) {
			if (task == null) {
				return false;
			}
			return this.task == task;
		}

		public bool IsClosed { get; private set; }

		protected override void OnClosed(EventArgs e) {
			base.OnClosed(e);
			IsClosed = true;
		}
	}
}

