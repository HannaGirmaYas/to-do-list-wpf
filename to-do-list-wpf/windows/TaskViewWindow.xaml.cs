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
		public static void OpenATaskViewWindow(to_doTask task) {
			var window = new TaskViewWindow();
			window.task = task;
			window.DataContext = window.task;
			window.Show();
		}
		public TaskViewWindow() {
			InitializeComponent();
			this.MouseDown += (sender, e) => {
				if (e.LeftButton == MouseButtonState.Pressed) {
					this.DragMove();
				}
			};
		}

		private to_doTask task;

		private void AddItem(object sender, RoutedEventArgs e) {
			this.task.AddNewItem();
		}

		private void RemoveItem(object sender, RoutedEventArgs e) {
			this.task.Items.Remove((sender as Button).DataContext as to_doTask.ChecklistItem);
		}

		private void CloseWindow(object sender, RoutedEventArgs e) {
			this.Close();
		}
	}
}

